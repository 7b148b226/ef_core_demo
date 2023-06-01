using System;
using System.ComponentModel.DataAnnotations;
using ef_6_with_.net_4.DAL.Extensions;

namespace ef_6_with_.net_4.DAL.Entities
{
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

        public decimal Field11 { get; set; }

        public decimal Field12 { get; set; }

        public decimal Field13 { get; set; }

        public decimal Field14 { get; set; }

        public DateTime Field15 { get; set; }
    }
}
