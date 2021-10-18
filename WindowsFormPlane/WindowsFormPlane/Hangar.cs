using System.Drawing;
using System.Collections.Generic;
namespace WindowsFormPlane
{
    public class Hangar<T> where T : class, ITransport
    {
        /// <summary>
        /// Список объектов, которые храним
        /// </summary>
        private readonly List<T> _places;
        /// <summary>
        /// Максимальное количество мест на парковке
        /// </summary>
        private readonly int _maxCount;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Размер парковочного места (ширина)
        /// </summary>
        private readonly int _placeSizeWidth = 223;
        /// <summary>
        /// Размер парковочного места (высота)
        /// </summary>
        private readonly int _placeSizeHeight = 140;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth">Рамзер парковки - ширина</param>
        /// <param name="picHeight">Рамзер парковки - высота</param>
        public Hangar(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _maxCount = width * height;
            _places = new List<T>();
            pictureWidth = picWidth;
            pictureHeight = picHeight;
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на парковку добавляется автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="car">Добавляемый автомобиль</param>
        /// <returns></returns>
        public static bool operator +(Hangar<T> p, T plane)
        {
            for (int i = 0; i < p._maxCount; i++)
            {
                bool isNullObject = p._places.Count > i && p._places[i] == null;
                if (isNullObject)
                {
                    int indexWidth = p.pictureWidth / p._placeSizeWidth;
                    int indexHeight = p.pictureHeight / p._placeSizeHeight;
                    plane.SetPosition(
                        p._placeSizeWidth * (i % indexWidth),
                        p._placeSizeHeight * (i / indexHeight),
                        p._placeSizeWidth, p._placeSizeHeight);

                    p._places[i] = plane;
                    return true;
                }
                else if (p._places.Count <= i)
                {
                    int indexWidth = p.pictureWidth / p._placeSizeWidth;
                    int indexHeight = p.pictureHeight / p._placeSizeHeight;
                    plane.SetPosition(
                        p._placeSizeWidth * (i % indexWidth), 
                        p._placeSizeHeight * (i / indexHeight), 
                        p._placeSizeWidth, p._placeSizeHeight);
                    p._places.Add(plane);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с парковки забираем автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        public static T operator -(Hangar<T> p, int index)
        {
            if ((index < p._maxCount || index > 0) && index < p._places.Count)
            {
                T plane = p._places[index];
                p._places[index] = null;
                return plane;
            }
            return null;
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Count; ++i)
            {
                if (_places[i] != null)
                {
                    _places[i].DrawTransport(g);
                }
            }
        }
        /// <summary>
        /// Метод отрисовки разметки парковочных мест
        /// </summary>
        /// <param name="g"></param>
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 2);
            for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
                {
                    //линия рамзетки места
                    g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i *
                   _placeSizeWidth + _placeSizeWidth / 2, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth,
               (pictureHeight / _placeSizeHeight) * _placeSizeHeight);
            }
        }
    }
}
