using ef_core_7_with_.net_7.DAL.Entities;
using ef_core_7_with_.net_7.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ef_core_7_with_.net_7.DAL;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Info> Infos { get; set; }

    public DbSet<Root> Roots { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Root>()
            .Property(x => x.Dict)
            .HasConversion(
                x => x.ToJson(),
                x => x.FromJson<IDictionary<int, string>>(null),
                new ValueComparer<IDictionary<int, string>>(
                    (f, s) => f.OrderBy(x => x.Key).SequenceEqual(s.OrderBy(x => x.Key)),
                    x => x.GetHashCode(),
                    x => x.ToDictionary(x => x.Key, x => x.Value)));

        builder.Entity<Root>()
            .OwnsOne(x => x.JsonNode, x =>
            {
                x.OwnsOne(x => x.Child);
                x.OwnsMany(x => x.Children);
                x.ToJson();
            });

        builder.Entity<Root>()
            .Property(x => x.ConversionNode)
            .HasConversion(
                x => x.ToJson(),
                x => x.FromJson<Node>(null),
                new ValueComparer<Node>(
                    (f, s) => f.Equals(s),
                    x => x.GetHashCode(),
                    x => x));
    }
}
