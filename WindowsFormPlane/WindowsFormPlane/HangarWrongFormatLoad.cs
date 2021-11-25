using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormPlane
{
    public class HangarWrongFormatLoad: Exception
    {
        public HangarWrongFormatLoad() : base("Неверный формат файла.")
        { }
    }
}
