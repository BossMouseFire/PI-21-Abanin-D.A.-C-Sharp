using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormPlane
{
	class Bomber: Plane
	{
		public bool StateBombs { private set; get; }

		public bool StateGun { private set; get; }

		public Color AdditionalColor
		{ private set; get; }

		public Bomber(int maxSpeed, float weight, Color mainColor, Color additionalColor, bool stateBombs, bool stateGun) :
			base(maxSpeed, weight, mainColor, 220, 140)
		{
			AdditionalColor = additionalColor;
			StateBombs = stateBombs;
			StateGun = stateGun;
		}

		public override void DrawTransport(Graphics g)
		{
			Brush brAdd = new SolidBrush(AdditionalColor);

			base.DrawTransport(g);

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
		}

	}
}
