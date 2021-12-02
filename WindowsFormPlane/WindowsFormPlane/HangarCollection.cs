using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormPlane
{
    public class HangarCollection
    {
        /// <summary>
        /// Словарь (хранилище) с парковками
        /// </summary>
        readonly Dictionary<string, Hangar<Vehicle>> hangarStages;
        /// <summary>
        /// Возвращение списка названий праковок
        /// </summary>
        public List<string> Keys => hangarStages.Keys.ToList();
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public HangarCollection(int pictureWidth, int pictureHeight)
        {
            hangarStages = new Dictionary<string, Hangar<Vehicle>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }

        /// <summary>
        /// Разделитель для записи информации в файл
        /// </summary>
        private readonly char separator = ':';

        /// <summary>
        /// Добавление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void AddHangar(string name)
        {
            if (!hangarStages.ContainsKey(name))
            {
                Hangar<Vehicle> value = new Hangar<Vehicle>(pictureWidth, pictureHeight);
                hangarStages.Add(name, value);
            }
        }
        /// <summary>
        /// Удаление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void DelHangar(string name)
        {
            hangarStages.Remove(name);
        }
        public Hangar<Vehicle> this[string ind]
        {
            get
            {
                Hangar<Vehicle> value;
                if (hangarStages.TryGetValue(ind, out value))
                {
                    return value;
                }
                return null;
            }
        }

        /// <summary>
        /// Сохранение информации по автомобилям на парковках в файл
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        /// <returns></returns>
        public void SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.Write($"HangarCollection{Environment.NewLine}");
                foreach (var level in hangarStages)
                {
                    //Начинаем парковку
                    sw.Write($"Hangar{separator}{level.Key}{Environment.NewLine}");

                    foreach(ITransport plane in level.Value)
                    {
                        if (plane.GetType().Name == "Plane")
                        {
                            sw.Write($"Plane{separator}");
                        }
                        if (plane.GetType().Name == "Bomber")
                        {
                            sw.Write($"Bomber{separator}");
                        }
                        //Записываемые параметры
                        sw.Write(plane + Environment.NewLine);
                    }
                }
            }
        }

        /// <summary>
        /// Загрузка нформации по автомобилям на парковках из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public void LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            string key = string.Empty;

            using (StreamReader fs = new StreamReader(filename))
            {
                string line = fs.ReadLine();

                if (line.Contains("HangarCollection"))
                {
                    hangarStages.Clear();
                    line = fs.ReadLine();
                }
                else
                {
                    throw new FormatException("Задан неверный формат.");
                }

                while (line != null)
                {
                    Vehicle plane = null;
                    if (line.Contains("Hangar") && !hangarStages.ContainsKey(line.Split(separator)[1]))
                    {
                        //начинаем новую парковку
                        key = line.Split(separator)[1];
                        hangarStages.Add(key, new Hangar<Vehicle>(pictureWidth,
                        pictureHeight));
                        continue;
                    }
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    if (line.Split(separator)[0] == "Plane")
                    {
                        plane = new Plane(line.Split(separator)[1]);
                    }
                    else if (line.Split(separator)[0] == "Bomber")
                    {
                        plane = new Bomber(line.Split(separator)[1]);
                    }
                    if (plane != null)
                    {
                        var result = hangarStages[key] + plane;
                        if (!result)
                        {
                            throw new TypeLoadException("Ангар переполнен");
                        }
                    }
                    line = fs.ReadLine();
                }
            }
        }
    }
}
