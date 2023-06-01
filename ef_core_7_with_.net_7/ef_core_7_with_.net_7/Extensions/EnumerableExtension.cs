namespace ef_core_7_with_.net_7.Extensions;

public static class EnumerableExtension
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> lst)
    {
        return lst is null || !lst.Any();
    }
}
