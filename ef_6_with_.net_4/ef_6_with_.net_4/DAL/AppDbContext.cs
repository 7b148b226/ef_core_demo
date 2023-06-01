using System.Data.Entity;
using ef_6_with_.net_4.DAL.Entities;

namespace ef_6_with_.net_4.DAL
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext() : base("Default") { }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Info>()
                .ToTable("Infos");

            builder.Entity<Info>()
                .Property(x => x.Field11)
                .HasPrecision(4, 2);

            builder.Entity<Info>()
                .Property(x => x.Field12)
                .HasPrecision(9, 5);

            builder.Entity<Info>()
                .Property(x => x.Field13)
                .HasPrecision(19, 10);

            builder.Entity<Info>()
                .Property(x => x.Field14)
                .HasPrecision(38, 19);
        }
    }
}
