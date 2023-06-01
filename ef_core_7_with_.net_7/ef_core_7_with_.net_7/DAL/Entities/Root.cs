using ef_core_7_with_.net_7.DAL.Extensions;

namespace ef_core_7_with_.net_7.DAL.Entities;

public sealed class Root : IIdHave<Guid>
{
    public Guid Id { get; set; }

    public IDictionary<int, string> Dict { get; set; }

    public Node JsonNode { get; set; }

    public Node ConversionNode { get; set; }

    public string NvarcharNode { get; set; }
}
