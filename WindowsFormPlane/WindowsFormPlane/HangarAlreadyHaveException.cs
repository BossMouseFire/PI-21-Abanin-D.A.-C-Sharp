using System;

namespace WindowsFormPlane
{
    public class HangarAlreadyHaveException: Exception
    {
        public HangarAlreadyHaveException() : base("В ангаре есть уже такой самолёт")
        {}
    }
}
