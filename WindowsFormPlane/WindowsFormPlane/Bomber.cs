using System;
using System.Drawing;

namespace WindowsFormPlane
{
	class Bomber: Plane
	{
		public bool StateBombs {set; get; }

		public bool StateGun { set; get; }

		public Color AdditionalColor
		{ private set; get; }

		public Bomber(int maxSpeed, float weight, Color mainColor, Color additionalColor, bool stateBombs, bool stateGun) :
			base(maxSpeed, weight, mainColor, 220, 140)
		{
			AdditionalColor = additionalColor;
			StateBombs = stateBombs;
			StateGun = stateGun;
		}

		public Bomber(string info) : base(info)
		{
			string[] strs = info.Split(separator);
			if (strs.Length == 6)
			{
				MaxSpeed = Convert.ToInt32(strs[0]);
				Weight = Convert.ToInt32(strs[1]);
				MainColor = Color.FromName(strs[2]);
				AdditionalColor = Color.FromName(strs[3]);
				StateBombs = Convert.ToBoolean(strs[4]);
				StateGun = Convert.ToBoolean(strs[5]);
			}
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

		public void SetAddColor(Color color)
        {
			AdditionalColor = color;
        }

		public override string ToString()
		{
			return
		   $"{base.ToString()}{separator}{AdditionalColor.Name}{separator}{StateBombs}{separator}{StateBombs}";
		}

	}
}
