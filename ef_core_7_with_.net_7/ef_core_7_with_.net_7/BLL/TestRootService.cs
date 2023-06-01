using ef_core_7_with_.net_7.DAL.Entities;
using ef_core_7_with_.net_7.DTO;
using ef_core_7_with_.net_7.Extensions;
using ef_core_7_with_.net_7.Static;

namespace ef_core_7_with_.net_7.BLL;

public sealed class TestRootService
{
    private RootService RootService { get; }

    private int LevelLimit { get; }

    private int ExpansionFactor { get; }

    public TestRootService(RootService rootService)
    {
        RootService = rootService;
        LevelLimit = 2;
        ExpansionFactor = 100;
    }

    public async Task FullJsonInsert()
    {
        await RootService.Add(new RootDto.Add
        {
            JsonNode = Build(LevelLimit, ExpansionFactor),
        });
    }

    private Node Build(int levelLimit, int expansionFactor)
    {
        var root = Build(0, 1, expansionFactor);
        Spawn(root, levelLimit, expansionFactor);

        return root;
    }

    private void Spawn(Node parent, int levelLimit, int expansionFactor)
    {
        var level = parent.Level + 1;
        if (level >= levelLimit)
            return;

        for (var x = 1; x <= expansionFactor; ++x)
        {
            var node = Build(level, x, expansionFactor);
            Spawn(node, levelLimit, expansionFactor);
            parent.Children.Add(node);
        }
    }

    private Node Build(int level, int orderNumber, int expansionFactor)
    {
        var childOrderNumber = expansionFactor + orderNumber;
        return new Node
        {
            Level = level,
            OrderNumber = orderNumber,
            Name = RandomString.AlphaNumeric(50),
            Child = new Node
            {
                Level = level + 1,
                OrderNumber = childOrderNumber,
                Name = RandomString.AlphaNumeric(50),
            },
            Children = new List<Node>(expansionFactor),
        };
    }

    public async Task FullConversionInsert()
    {
        var id = await RootService.Add(new RootDto.Add
        {
            ConversionNode = Build(LevelLimit, ExpansionFactor),
        });
    }

    public async Task FullNvarcharInsert()
    {
        var id = await RootService.Add(new RootDto.Add
        {
            NvarcharNode = Build(LevelLimit, ExpansionFactor).ToJson(),
        });
    }

    public async Task FullJsonUpdate(Guid id)
    {
        await RootService.Edit(new RootDto.Edit
        {
            Id = id,
            JsonNode = Build(LevelLimit, ExpansionFactor),
        });
    }

    public async Task FullConversionUpdate(Guid id)
    {
        await RootService.Edit(new RootDto.Edit
        {
            Id = id,
            ConversionNode = Build(LevelLimit, ExpansionFactor),
        });
    }

    public async Task FullNvarcharUpdate(Guid id)
    {
        await RootService.Edit(new RootDto.Edit
        {
            Id = id,
            NvarcharNode = Build(LevelLimit, ExpansionFactor).ToJson(),
        });
    }

    public async Task FullJsonQuery(Guid id)
    {
        var node = await RootService.Select(id, x => x.JsonNode);
    }

    public async Task FullConversionQuery(Guid id)
    {
        var node = await RootService.Select(id, x => x.ConversionNode);
    }

    public async Task FullNvarcharQuery(Guid id)
    {
        var node = (await RootService.Select(id, x => x.NvarcharNode)).FromJson<Node>();
    }

    public async Task PartialJsonQuery(Guid id)
    {
        var name = await RootService.Select(id, x => x.JsonNode.Child.Name);
    }

    public async Task PartialConversionQuery(Guid id)
    {
        var name = await RootService.Select(id, x => x.ConversionNode.Child.Name);
    }

    public async Task PartialNvarcharQuery(Guid id)
    {
        var name = (await RootService.Select(id, x => x.NvarcharNode)).FromJson<Node>().Child.Name;
    }

    public async Task PartialJsonUpdate(Guid id)
    {
        await RootService.PartialJsonUpdate(id, "new name");
    }

    public async Task PartialConversionUpdate(Guid id)
    {
        await RootService.PartialConversionUpdate(id, "new name");
    }

    public async Task PartialNvarcharUpdate(Guid id)
    {
        await RootService.PartialNvarcharUpdate(id, "new name");
    }
}
