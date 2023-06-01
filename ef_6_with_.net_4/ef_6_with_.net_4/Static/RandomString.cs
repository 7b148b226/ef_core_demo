using System;
using System.Collections.Generic;
using System.Text;

namespace ef_6_with_.net_4.Static
{
    public static class RandomString
    {
        private static string Numbers { get; }

        private static string LowerAlphas { get; }

        private static string LowerSpecials { get; }

        private static string UpperAlphas { get; }

        private static string Alphas { get; }

        private static string AlphaNumbers { get; }

        static RandomString()
        {
            Numbers = "0123456789";
            LowerAlphas = "abcdefghijklmnopqrstuvwxyz";
            LowerSpecials = "bcdfghjkmnpqrstvwxyzaeouaeouaeou";
            UpperAlphas = LowerAlphas.ToUpper();
            Alphas = $"{LowerAlphas}{UpperAlphas}";
            AlphaNumbers = $"{Numbers}{LowerAlphas}{UpperAlphas}";
        }

        public static string AlphaNumeric(int length)
        {
            return Generate(AlphaNumbers, length);
        }

        public static string Alpha(int length)
        {
            return Generate(Alphas, length);
        }

        public static string UpperAlpha(int length)
        {
            return Generate(UpperAlphas, length);
        }

        public static string Mix(int specialLen, int numericLen)
        {
            return $"{LowerSpecial(specialLen)}{Numeric(numericLen)}";
        }

        public static string LowerSpecial(int length)
        {
            return Generate(LowerSpecials, length);
        }

        public static string LowerAlpha(int length)
        {
            return Generate(LowerAlphas, length);
        }

        public static string Numeric(int length)
        {
            return Generate(Numbers, length);
        }

        public static IEnumerable<string> Series(Func<int, string> gen, int count, int length)
        {
            var lst = new HashSet<string>();
            while (lst.Count < count)
                lst.Add(gen(length));

            return lst;
        }

        private static string Generate(string source, int length)
        {
            var rnd = new Random();
            var str = new StringBuilder(length);
            for (var _ = 0; _ < length; ++_)
                str.Append(source[rnd.Next(source.Length)]);

            return str.ToString();
        }
    }
}
