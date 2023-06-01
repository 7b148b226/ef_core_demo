using ef_core_7_with_.net_7.DAL.Entities;
using ef_core_7_with_.net_7.DAL.Extensions;

namespace ef_core_7_with_.net_7.DTO;

public static class RootDto
{
    public sealed record Add
    {
        public IDictionary<int, string> Dict { get; init; }

        public Node JsonNode { get; init; }

        public Node ConversionNode { get; init; }

        public string NvarcharNode { get; init; }
    }

    public sealed record Edit : IIdHave<Guid>
    {
        public Guid Id { get; set; }

        public IDictionary<int, string> Dict { get; init; }

        public Node JsonNode { get; init; }

        public Node ConversionNode { get; init; }

        public string NvarcharNode { get; init; }
    }

    public sealed record List
    {
        public Guid Id { get; init; }

        public Dictionary<int, string> Dict { get; init; }

        public Node Node { get; init; }
    }
}
