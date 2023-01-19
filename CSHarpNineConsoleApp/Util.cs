using System;

namespace CSHarpNineConsoleApp
{
    public static class Util
    {
        public static bool IsAnyValueZero((decimal, decimal) aTuple)
        {
            switch (aTuple)
            {
                case ValueTuple<decimal, decimal> t when t.Item1 == 0 || t.Item2 == 0:
                    return true;
                default:
                    break;
            }
            return false;
        }

        public static bool IsAnyValueZero2((decimal, decimal) aTuple)
        {
            switch (aTuple)
            {
                case (decimal i1, decimal i2) when i1 == 0 || i2 == 0:
                    return true;
            }
            return false;
        }

    }
}
