namespace ef_core_7_with_.net_7.DAL.Entities;

public sealed record Node
{
    public int Level { get; set; }

    public int OrderNumber { get; set; }

    public string Name { get; set; }

    public Node Child { get; set; }

    public ICollection<Node> Children { get; set; }
}
