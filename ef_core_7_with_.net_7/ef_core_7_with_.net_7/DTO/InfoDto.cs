using ef_core_7_with_.net_7.DAL.Extensions;

namespace ef_core_7_with_.net_7.DTO;

public static class InfoDto
{
    public interface IInfo
    {
        string Field1 { get; init; }

        string Field2 { get; init; }

        string Field3 { get; init; }

        string Field4 { get; init; }

        string Field5 { get; init; }

        bool Field6 { get; init; }

        byte Field7 { get; init; }

        short Field8 { get; init; }

        int Field9 { get; init; }

        long Field10 { get; init; }

        decimal Field11 { get; init; }

        decimal Field12 { get; init; }

        decimal Field13 { get; init; }

        decimal Field14 { get; init; }

        DateTime Field15 { get; init; }
    }

    public sealed record Add : IInfo
    {
        public string Field1 { get; init; }

        public string Field2 { get; init; }

        public string Field3 { get; init; }

        public string Field4 { get; init; }

        public string Field5 { get; init; }

        public bool Field6 { get; init; }

        public byte Field7 { get; init; }

        public short Field8 { get; init; }

        public int Field9 { get; init; }

        public long Field10 { get; init; }

        public decimal Field11 { get; init; }

        public decimal Field12 { get; init; }

        public decimal Field13 { get; init; }

        public decimal Field14 { get; init; }

        public DateTime Field15 { get; init; }
    }

    public sealed record List
    {
        public Guid Id { get; init; }

        public string Field1 { get; init; }

        public string Field2 { get; init; }

        public string Field3 { get; init; }

        public string Field4 { get; init; }

        public string Field5 { get; init; }

        public string Field6 { get; init; }

        public byte Field7 { get; init; }

        public short Field8 { get; init; }

        public int Field9 { get; init; }

        public long Field10 { get; init; }

        public decimal Field11 { get; init; }

        public decimal Field12 { get; init; }

        public decimal Field13 { get; init; }

        public decimal Field14 { get; init; }

        public DateTime Field15 { get; init; }
    }

    public sealed record ById : IIdHave<Guid>
    {
        public Guid Id { get; set; }

        public string Field1 { get; init; }

        public string Field2 { get; init; }

        public string Field3 { get; init; }

        public string Field4 { get; init; }

        public string Field5 { get; init; }

        public string Field6 { get; init; }

        public byte Field7 { get; init; }

        public short Field8 { get; init; }

        public int Field9 { get; init; }

        public long Field10 { get; init; }

        public decimal Field11 { get; init; }

        public decimal Field12 { get; init; }

        public decimal Field13 { get; init; }

        public decimal Field14 { get; init; }

        public DateTime Field15 { get; init; }
    }

    public sealed record Edit : IIdHave<Guid>, IInfo
    {
        public Guid Id { get; set; }

        public string Field1 { get; init; }

        public string Field2 { get; init; }

        public string Field3 { get; init; }

        public string Field4 { get; init; }

        public string Field5 { get; init; }

        public bool Field6 { get; init; }

        public byte Field7 { get; init; }

        public short Field8 { get; init; }

        public int Field9 { get; init; }

        public long Field10 { get; init; }

        public decimal Field11 { get; init; }

        public decimal Field12 { get; init; }

        public decimal Field13 { get; init; }

        public decimal Field14 { get; init; }

        public DateTime Field15 { get; init; }
    }
}
