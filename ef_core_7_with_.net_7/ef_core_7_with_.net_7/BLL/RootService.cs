using ef_core_7_with_.net_7.DAL;
using ef_core_7_with_.net_7.DAL.Entities;
using ef_core_7_with_.net_7.DAL.Extensions;
using ef_core_7_with_.net_7.Extensions;

namespace ef_core_7_with_.net_7.BLL;

public sealed class RootService : EntityService<Root, Guid>
{
    public RootService(AppDbContext context) : base(context) { }

    public async Task PartialJsonUpdate(Guid id, string name)
    {
        var entity = await Context.Set<Root>().ById(id);
        entity.JsonNode.Child.Name = name;

        await Context.SaveChangesAsync();
    }

    public async Task PartialConversionUpdate(Guid id, string name)
    {
        var entity = await Context.Set<Root>().ById(id);
        entity.ConversionNode.Child.Name = name;

        await Context.SaveChangesAsync();
    }

    public async Task PartialNvarcharUpdate(Guid id, string name)
    {
        var entity = await Context.Set<Root>().ById(id);
        var node = entity.NvarcharNode.FromJson<Node>();
        node.Child.Name = name;
        entity.NvarcharNode = node.ToJson();

        await Context.SaveChangesAsync();
    }
}
