using System;

namespace WindowsFormPlane
{
    public class HangarNotFoundException : Exception
    {
        public HangarNotFoundException(int i) : base("Не найден автомобиль по месту " + i)
        { }
    }
}
