using System.ComponentModel.DataAnnotations;
using ef_core_7_with_.net_7.DAL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ef_core_7_with_.net_7.DAL.Entities;

public sealed class Info : IIdHave<Guid>
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(4)]
    public string Field1 { get; set; }

    [MaxLength(64)]
    public string Field2 { get; set; }

    [MaxLength(1024)]
    public string Field3 { get; set; }

    [MaxLength(4000)]
    public string Field4 { get; set; }

    public string Field5 { get; set; }

    public bool Field6 { get; set; }

    public byte Field7 { get; set; }

    public short Field8 { get; set; }

    public int Field9 { get; set; }

    public long Field10 { get; set; }

    [Precision(4, 2)]
    public decimal Field11 { get; set; }

    [Precision(9, 5)]
    public decimal Field12 { get; set; }

    [Precision(19, 10)]
    public decimal Field13 { get; set; }

    [Precision(38, 19)]
    public decimal Field14 { get; set; }

    public DateTime Field15 { get; set; }
}
