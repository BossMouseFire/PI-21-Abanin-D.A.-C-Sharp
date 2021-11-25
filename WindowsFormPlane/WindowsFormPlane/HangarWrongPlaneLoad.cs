using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormPlane
{
    public class HangarWrongPlaneLoad: Exception
    {
        public HangarWrongPlaneLoad() : base("Не удалось загрузить автомобиль на парковку")
        { }
    }
}
