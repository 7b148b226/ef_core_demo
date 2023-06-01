using System.Linq.Expressions;
using ef_core_7_with_.net_7.DAL;
using ef_core_7_with_.net_7.DAL.Extensions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ef_core_7_with_.net_7.BLL;

public abstract class EntityService<TE, TK>
    where TE : class, IIdHave<TK>
    where TK : IEquatable<TK>
{
    protected AppDbContext Context { get; }

    protected EntityService(AppDbContext context)
    {
        Context = context;
    }

    public async Task<TK> Add<T>(T dto, CancellationToken cancellationToken = default)
    {
        return await Add(dto, x => x.Id, cancellationToken);
    }

    public async Task<TP> Add<T, TP>(T dto, Func<TE, TP> selector, CancellationToken cancellationToken = default)
    {
        var entity = dto.Adapt<TE>();
        await Context.Set<TE>().AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);

        return selector(entity);
    }

    public async Task<IEnumerable<T>> List<T>(Expression<Func<TE, bool>> predicate = null, CancellationToken cancellationToken = default)
    {
        predicate ??= x => true;
        return await Context.Set<TE>()
            .AsNoTracking()
            .Where(predicate)
            .ProjectToType<T>()
            .ToListAsync(cancellationToken);
    }

    public async Task<T> ById<T>(TK id, CancellationToken cancellationToken = default) where T : class, IIdHave<TK>
    {
        return await Context.Set<TE>()
            .AsNoTracking()
            .ProjectToType<T>()
            .ById(id, cancellationToken);
    }

    public async Task Edit<T>(T dto, CancellationToken cancellationToken = default) where T : class, IIdHave<TK>
    {
        var entity = await Context.Set<TE>().ById(dto.Id, cancellationToken);
        dto.Adapt(entity);

        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(TK id, CancellationToken cancellationToken = default)
    {
        var entity = await Context.Set<TE>().ById(id, cancellationToken);
        Context.Set<TE>().Remove(entity);

        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<T>> Select<T>(Expression<Func<TE, T>> selector, CancellationToken cancellationToken = default)
    {
        return await Context.Set<TE>()
            .AsNoTracking()
            .Select(selector)
            .ToListAsync(cancellationToken);
    }

    public async Task<IList<T>> Select<T>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, T>> selector, CancellationToken cancellationToken = default)
    {
        return await Context.Set<TE>()
            .AsNoTracking()
            .Where(predicate)
            .Select(selector)
            .ToListAsync(cancellationToken);
    }

    public async Task<T> Select<T>(TK id, Expression<Func<TE, T>> selector, bool isThrow = true, CancellationToken cancellationToken = default)
    {
        return await Select(x => x.Id.Equals(id), selector, isThrow, cancellationToken);
    }

    public async Task<T> Select<T>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, T>> selector, bool isThrow = true, CancellationToken cancellationToken = default)
    {
        var query = Context.Set<TE>()
            .AsNoTracking()
            .Where(predicate)
            .Select(selector);

        if (isThrow && !await query.AnyAsync(cancellationToken))
            throw new ArgumentException($"2502. {typeof(TE).Name} not found, predicate = {predicate}");

        return await query.FirstAsync(cancellationToken);
    }
}
