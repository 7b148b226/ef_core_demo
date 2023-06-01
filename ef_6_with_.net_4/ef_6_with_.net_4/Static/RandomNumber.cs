using System;
using System.Linq;

namespace ef_6_with_.net_4.Static
{
    public static class RandomNumber
    {
        public static short Short()
        {
            return Convert.ToInt16(new Random().Next(short.MinValue, short.MaxValue));
        }

        public static long Long()
        {
            return Convert.ToInt64($"8{RandomString.Numeric(18)}");
        }

        public static decimal Decimal(byte precision, byte scale)
        {
            var longMaxStr = decimal.MaxValue.ToString();
            var intLength = precision - scale;
            var intPart = RandomString.Numeric(intLength);
            var fraPart = RandomString.Numeric(scale);
            if (precision > 28 && string.CompareOrdinal(new string(longMaxStr.Take(intLength).ToArray()), intPart) < 0)
                intPart = $"6{new string(intPart.Skip(1).ToArray())}";

            return Convert.ToDecimal($"{intPart}.{fraPart}");
        }

        public static int Int()
        {
            return new Random().Next();
        }

        public static bool Bool()
        {
            return RandomNumber.Byte() % 2 == 0;
        }

        public static byte Byte()
        {
            return Convert.ToByte(new Random().Next(byte.MinValue, byte.MaxValue));
        }
    }
}
