using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormPlane
{
	class Bomber
	{
		/// <summary>
		/// Левая координата отрисовки
		/// </summary>
		private float _startPosX;
		/// <summary>
		/// Правая кооридната отрисовки автомобиля
		/// </summary>
		private float _startPosY;
		/// <summary>
		/// Ширина окна отрисовки
		/// </summary>
		private int _pictureWidth;
		/// <summary>
		/// Высота окна отрисовки
		/// </summary>
		private int _pictureHeight;

		/// <summary>
		/// Ширина отрисовки бомбардировщика
		/// </summary>
		private readonly int bomberWidth = 220;

		/// <summary>
		/// Высота отрисовки бомбардировщика
		/// </summary>
		private readonly int bomberHeight = 140;

		/// <summary>
		/// Максимальная скорость
		/// </summary>
		public int MaxSpeed { private set; get; }
		/// <summary>
		/// Вес бомбардировщика
		/// </summary>
		/// 

		public bool StateBombs { private set; get; }

		public bool StateGun { private set; get; }

		public float Weight { private set; get; }
		/// <summary>
		/// Основной цвет бомбардировщика
		/// </summary>
		public Color MainColor { private set; get; }
		/// <summary>
		/// Дополнительный цвет
		/// </summary>
		public Color AdditionalColor
		{ private set; get; }

		public void Init(int maxSpeed, float weight, Color mainColor, Color additionalColor, bool stateBombs, bool stateGun)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
			AdditionalColor = additionalColor;
			StateBombs = stateBombs;
			StateGun = stateGun;
		}


		public void SetPosition(int x, int y, int width, int height)
		{
			_startPosX = x;
			_startPosY = y;
			_pictureWidth = width;
			_pictureHeight = height;
		}

		public void MoveTransport(Direction direction)
		{
			float step = MaxSpeed * 100 / Weight;
			switch (direction)
			{
				// вправо
				case Direction.Right:
					if (_startPosX + step < _pictureWidth - bomberWidth)
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
					if (_startPosY + step < _pictureHeight - bomberHeight)
					{
						_startPosY += step;
					}
					break;
			}
		}

		public void DrawBomber(Graphics g)
		{
			Brush brMain = new SolidBrush(MainColor);
			Brush brAdd = new SolidBrush(AdditionalColor);

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

			if (StateBombs)
			{
				// верхние бомбы
				g.FillRectangle(brAdd, _startPosX + 52, _startPosY + 40, 10, 10);
				g.FillRectangle(brAdd, _startPosX + 67, _startPosY + 20, 10, 10);

				// нижние бомбы
				g.FillRectangle(brAdd, _startPosX + 52, _startPosY + 90, 10, 10);
				g.FillRectangle(brAdd, _startPosX + 67, _startPosY + 110, 10, 10);
			}

			if (StateGun)
			{
				PointF[] pointsLower =
			{
				new PointF(_startPosX + 140, _startPosY + 70),
				new PointF(_startPosX + 140, _startPosY + 40),
				new PointF(_startPosX + 110, _startPosY + 70),
			};
				g.FillPolygon(brAdd, pointsLower);
				g.FillEllipse(brAdd, _startPosX + 130, _startPosY + 30, 20, 20);
			}

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

	}
}
