using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ef_6_with_.net_4.DAL.Extensions
{
    public static class IdHaveExtension
    {
        public static async Task<T> ById<T, TKey>(this IQueryable<T> query, TKey id)
            where T : class, IIdHave<TKey>
            where TKey : IEquatable<TKey>
        {
            var entity = await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity == null)
                throw new ArgumentException($"2550. entity with code = '{id}' not found", nameof(id));

            return entity;
        }
    }
}
