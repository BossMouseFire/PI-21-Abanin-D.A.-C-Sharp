using System.Drawing;
using System.Collections.Generic;
using System.Collections;

namespace WindowsFormPlane
{
    public class Hangar<T>: IEnumerator<T>, IEnumerable<T>  where T : class, ITransport
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

        private int _currentIndex = -1;
        public T Current => _places[_currentIndex];
        object IEnumerator.Current => _places[_currentIndex];


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
            if (p._places.Count >= p._maxCount)
            {
                throw new HangarOverflowException();
            }

            if (p._places.Contains(plane))
            {
                throw new HangarAlreadyHaveException();
            }

            p._places.Add(plane);
            return true;
        }
        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с парковки забираем автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        public static T operator -(Hangar<T> p, int index)
        {
            if (index < 0  || index >= p._places.Count)
            {
                throw new HangarNotFoundException(index);
            }
            T plane = p._places[index];
            p._places.RemoveAt(index);
            return plane;
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
                int indexWidth = pictureWidth / _placeSizeWidth;
                int indexHeight = pictureHeight / _placeSizeHeight;
                _places[i].SetPosition(
                        _placeSizeWidth * (i % indexWidth),
                        _placeSizeHeight * (i / indexHeight),
                        _placeSizeWidth, _placeSizeHeight);
                _places[i].DrawTransport(g);
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

        /// <summary>
        /// Функция получения элементы из списка
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetNext(int index)
        {
            if (index < 0 || index >= _places.Count)
            {
                return null;
            }
            return _places[index];
        }

        public void Sort() => _places.Sort((IComparer<T>) new PlaneComparer());
     
        public void Dispose()
        {
        }
        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _places.Count;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

    }
}
