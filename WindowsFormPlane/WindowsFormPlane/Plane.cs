using System;
using System.Drawing;

namespace WindowsFormPlane
{
	public class Plane : Vehicle, IEquatable<Plane>
	{
		/// <summary>
		/// Ширина отрисовки самолёта
		/// </summary>
		private readonly int planeWidth = 210;

		/// <summary>
		/// Высота отрисовки самолёта
		/// </summary>
		private readonly int planeHeight = 140;

		/// <summary>
		/// Разделитель для записи информации по объекту в файл
		/// </summary>
		protected readonly char separator = ';';

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="maxSpeed">Максимальная скорость</param>
		/// <param name="weight">Вес самолёта</param>
		/// <param name="mainColor">Основной цвет самолёта</param>
		public Plane(int maxSpeed, float weight, Color mainColor)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
		}

		/// <summary>
		/// Конструктор для загрузки с файла
		/// </summary>
		/// <param name="info">Информация по объекту</param>
		public Plane(string info)
		{
			string[] strs = info.Split(separator);
			if (strs.Length == 3)
			{
				MaxSpeed = Convert.ToInt32(strs[0]);
				Weight = Convert.ToInt32(strs[1]);
				MainColor = Color.FromName(strs[2]);
			}
		}

		/// <summary>
		/// Конструкторс изменением размеров машины
		/// </summary>
		/// <param name="maxSpeed">Максимальная скорость</param>
		/// <param name="weight">Вес автомобиля</param>
		/// <param name="mainColor">Основной цвет кузова</param>
		/// <param name="planeWidth">Ширина отрисовки самолёта</param>
		/// <param name="planeHeight">Высота отрисовки самолёта</param>
		protected Plane(int maxSpeed, float weight, Color mainColor, int planeWidth, int planeHeight)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
			this.planeWidth = planeWidth;
			this.planeHeight = planeHeight;
		}
		public override void MoveTransport(Direction direction)
		{
			float step = MaxSpeed * 100 / Weight;
			switch (direction)
			{
				// вправо
				case Direction.Right:
					if (_startPosX + step < _pictureWidth - planeWidth)
					{
						_startPosX += step;
					}
					break;
				//влево
				case Direction.Left:
					if (_startPosX - step > 0)
					{
						_startPosX -= step;
					}
					break;
				//вверх
				case Direction.Up:
					if (_startPosY - step > 0)
					{
						_startPosY -= step;
					}
					break;
				//вниз
				case Direction.Down:
					if (_startPosY + step < _pictureHeight - planeHeight)
					{
						_startPosY += step;
					}
					break;
			}
		}

		public override void DrawTransport(Graphics g)
		{
			Brush brMain = new SolidBrush(MainColor);

			PointF[] points =
			{
				new PointF(_startPosX, _startPosY + 70),
				new PointF(_startPosX + 10, _startPosY + 60),
				new PointF(_startPosX + 175, _startPosY + 60),
				new PointF(_startPosX + 220, _startPosY + 70),
				new PointF(_startPosX + 175, _startPosY + 80),
				new PointF(_startPosX + 10, _startPosY + 80),
			};
			g.FillPolygon(brMain, points);

			//Хвост
			PointF[] pointsTail =
			{
				new PointF(_startPosX + 155, _startPosY + 70),
				new PointF(_startPosX + 185, _startPosY + 30),
				new PointF(_startPosX + 185, _startPosY + 80),
				new PointF(_startPosX + 185, _startPosY + 110),
			};
			g.FillPolygon(brMain, pointsTail);

			//Верхнее крыло

			PointF[] pointsUpperWing =
			{
				new PointF(_startPosX + 50, _startPosY + 60),
				new PointF(_startPosX + 90, _startPosY + 5),
				new PointF(_startPosX + 100, _startPosY + 5),
				new PointF(_startPosX + 70, _startPosY + 60),
			};
			g.FillPolygon(brMain, pointsUpperWing);

			// нижнее крыло

			PointF[] pointsLowerWing =
			{
				new PointF(_startPosX + 50, _startPosY + 80),
				new PointF(_startPosX + 90, _startPosY + 135),
				new PointF(_startPosX + 100, _startPosY + 135),
				new PointF(_startPosX + 70, _startPosY + 80),
			};

			g.FillPolygon(brMain, pointsLowerWing);
		}

		public override string ToString()
		{
			return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor.Name}";
		}

		/// <summary>
		/// Метод интерфейса IEquatable для класса Car
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals(Plane other)
		{
			if (other == null)
			{
				return false;
			}
			if (GetType().Name != other.GetType().Name)
			{
				return false;
			}
			if (MaxSpeed != other.MaxSpeed)
			{
				return false;
			}
			if (Weight != other.Weight)
			{
				return false;
			}
			if (MainColor != other.MainColor)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// Перегрузка метода от object
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(Object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is Plane planeObj))
			{
				return false;
		    }
			else
			{
				return Equals(planeObj);
			}
		}

	}
}
