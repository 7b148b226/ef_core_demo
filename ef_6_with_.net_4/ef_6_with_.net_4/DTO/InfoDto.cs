using System;
using ef_6_with_.net_4.DAL.Extensions;

namespace ef_6_with_.net_4.DTO
{
    public static class InfoDto
    {
        public interface IInfo
        {
            string Field1 { get; set; }

            string Field2 { get; set; }

            string Field3 { get; set; }

            string Field4 { get; set; }

            string Field5 { get; set; }

            bool Field6 { get; set; }

            byte Field7 { get; set; }

            short Field8 { get; set; }

            int Field9 { get; set; }

            long Field10 { get; set; }

            decimal Field11 { get; set; }

            decimal Field12 { get; set; }

            decimal Field13 { get; set; }

            decimal Field14 { get; set; }

            DateTime Field15 { get; set; }
        }

        public sealed class Add : IInfo
        {
            public string Field1 { get; set; }

            public string Field2 { get; set; }

            public string Field3 { get; set; }

            public string Field4 { get; set; }

            public string Field5 { get; set; }

            public bool Field6 { get; set; }

            public byte Field7 { get; set; }

            public short Field8 { get; set; }

            public int Field9 { get; set; }

            public long Field10 { get; set; }

            public decimal Field11 { get; set; }

            public decimal Field12 { get; set; }

            public decimal Field13 { get; set; }

            public decimal Field14 { get; set; }

            public DateTime Field15 { get; set; }
        }

        public sealed class List
        {
            public Guid Id { get; set; }

            public string Field1 { get; set; }

            public string Field2 { get; set; }

            public string Field3 { get; set; }

            public string Field4 { get; set; }

            public string Field5 { get; set; }

            public bool Filed6 { get; set; }

            public byte Field7 { get; set; }

            public short Field8 { get; set; }

            public int Field9 { get; set; }

            public long Field10 { get; set; }

            public decimal Field11 { get; set; }

            public decimal Field12 { get; set; }

            public decimal Field13 { get; set; }

            public decimal Field14 { get; set; }

            public DateTime Field15 { get; set; }
        }

        public sealed class ById : IIdHave<Guid>
        {
            public Guid Id { get; set; }

            public string Field1 { get; set; }

            public string Field2 { get; set; }

            public string Field3 { get; set; }

            public string Field4 { get; set; }

            public string Field5 { get; set; }

            public bool Field6 { get; set; }

            public byte Field7 { get; set; }

            public short Field8 { get; set; }

            public int Field9 { get; set; }

            public long Field10 { get; set; }

            public decimal Field11 { get; set; }

            public decimal Field12 { get; set; }

            public decimal Field13 { get; set; }

            public decimal Field14 { get; set; }

            public DateTime Field15 { get; set; }
        }

        public sealed class Edit : IIdHave<Guid>, IInfo
        {
            public Guid Id { get; set; }

            public string Field1 { get; set; }

            public string Field2 { get; set; }

            public string Field3 { get; set; }

            public string Field4 { get; set; }

            public string Field5 { get; set; }

            public bool Field6 { get; set; }

            public byte Field7 { get; set; }

            public short Field8 { get; set; }

            public int Field9 { get; set; }

            public long Field10 { get; set; }

            public decimal Field11 { get; set; }

            public decimal Field12 { get; set; }

            public decimal Field13 { get; set; }

            public decimal Field14 { get; set; }

            public DateTime Field15 { get; set; }
        }
    }
}
