using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ef_6_with_.net_4.DAL;
using ef_6_with_.net_4.DAL.Extensions;
using Mapster;

namespace ef_6_with_.net_4.BLL
{
    public abstract class EntityService<TE, TK>
        where TE : class, IIdHave<TK>
        where TK : IEquatable<TK>
    {
        protected AppDbContext Context { get; }

        protected EntityService(AppDbContext context)
        {
            Context = context;
        }

        public async Task<TK> Add<T>(T dto, TypeAdapterConfig cnf = default)
        {
            var entity = dto.Adapt<TE>(cnf);
            Context.Set<TE>().Add(entity);
            await Context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<T>> List<T>(Expression<Func<TE, bool>> predicate = null)
        {
            if (predicate == null)
                predicate = x => true;

            return await Context.Set<TE>()
                .AsNoTracking()
                .Where(predicate)
                .ProjectToType<T>()
                .ToListAsync();
        }

        public async Task<T> ById<T>(TK id) where T : class, IIdHave<TK>
        {
            return await Context.Set<TE>()
                .AsNoTracking()
                .ProjectToType<T>()
                .ById(id);
        }

        public async Task Edit<T>(T dto) where T : class, IIdHave<TK>
        {
            var entity = await Context.Set<TE>().ById(dto.Id);
            dto.Adapt(entity);

            await Context.SaveChangesAsync();
        }

        public async Task Delete(TK id)
        {
            var entity = await Context.Set<TE>().ById(id);
            Context.Set<TE>().Remove(entity);

            await Context.SaveChangesAsync();
        }

        public async Task<IList<T>> Select<T>(Expression<Func<TE, T>> selector)
        {
            return await Context.Set<TE>()
                .AsNoTracking()
                .Select(selector)
                .ToListAsync();
        }

        public async Task<IList<T>> Select<T>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, T>> selector)
        {
            return await Context.Set<TE>()
                .AsNoTracking()
                .Where(predicate)
                .Select(selector)
                .ToListAsync();
        }

        public async Task<T> SelectById<T>(TK id, Expression<Func<TE, T>> selector, bool isThrow = true)
        {
            return await SelectFirst(x => x.Id.Equals(id), selector, isThrow);
        }

        public async Task<T> SelectFirst<T>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, T>> selector,
            bool isThrow = true)
        {
            var query = Context.Set<TE>()
                .AsNoTracking()
                .Where(predicate)
                .Select(selector);

            var entity = await query.FirstOrDefaultAsync();
            if (isThrow && entity == null)
                throw new ArgumentException($"2502. {typeof(TE).Name} not found, predicate = {predicate}");

            return entity;
        }
    }
}
