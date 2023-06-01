namespace ef_core_7_with_.net_7.Static;

public static class RandomNumber
{
    public static short Short()
    {
        return Convert.ToInt16(new Random().Next(short.MinValue, short.MaxValue));
    }

    public static long Long()
    {
        return new Random().NextInt64();
    }

    public static decimal Decimal(byte precision, byte scale)
    {
        var longMaxStr = decimal.MaxValue.ToString();
        var intLength = precision - scale;
        var intPart = RandomString.Numeric(intLength);
        var fraPart = RandomString.Numeric(scale);
        if (precision > 28 && string.CompareOrdinal(longMaxStr[..intLength], intPart) < 0)
            intPart = $"6{intPart[1..]}";

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
