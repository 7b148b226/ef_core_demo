using Microsoft.EntityFrameworkCore;

namespace ef_core_7_with_.net_7.DAL.Extensions;

public static class IdHaveExtension
{
    public static async Task<T> ById<T, TKey>(this IQueryable<T> query, TKey id, CancellationToken cancellationToken = default)
        where T : class, IIdHave<TKey>
        where TKey : IEquatable<TKey>
    {
        return await query.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
               ?? throw new ArgumentException($"2501. entity with code = '{id}' not found", nameof(id));
    }
}
