using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormPlane
{
    public class PlaneComparer: IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {

            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }

        private int ComparerCar(Plane x, Plane y)
        {
            var res = Compare(x, y);
            if (res != 0)
            {
                return res;
            }
            return 0;
        }

        private int ComparerSportCar(Bomber x, Bomber y)
        {
            var res = ComparerCar(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.AdditionalColor != y.AdditionalColor)
            {
                return x.AdditionalColor.Name.CompareTo(y.AdditionalColor.Name);
            }
            if (x.StateBombs != y.StateBombs)
            {
                return x.StateBombs.CompareTo(y.StateBombs);
            }
            if (x.StateGun != y.StateGun)
            {
                return x.StateGun.CompareTo(y.StateGun);
            }
            return 0;
        }
    }
}
