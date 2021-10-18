using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
