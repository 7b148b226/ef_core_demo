using ef_core_7_with_.net_7.DAL;
using ef_core_7_with_.net_7.DAL.Entities;
using ef_core_7_with_.net_7.DTO;
using EFCore.BulkExtensions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ef_core_7_with_.net_7.BLL;

public sealed class InfoService : EntityService<Info, Guid>
{
    public InfoService(AppDbContext context) : base(context) { }

    public async Task MultipleInsert(InfoDto.Add dto, int count)
    {
        for (var _ = 0; _ < count; ++_)
            await Context.Set<Info>().AddAsync(dto.Adapt<Info>());

        await Context.SaveChangesAsync();
    }

    public async Task BulkInsert(InfoDto.Add dto, int count)
    {
        var cnf = new TypeAdapterConfig();
        cnf.NewConfig<InfoDto.Add, Info>()
            .Map(x => x.Id, _ => Guid.NewGuid());

        var lst = new List<Info>();
        for (var _ = 0; _ < count; ++_)
            lst.Add(dto.Adapt<Info>(cnf));

        await Context.BulkInsertAsync(lst);

        await Context.SaveChangesAsync();
    }

    public async Task SingleExecuteUpdate(InfoDto.Edit dto)
    {
        await Context.Set<Info>()
            .Where(x => x.Id == dto.Id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Field1, _ => dto.Field1)
                .SetProperty(x => x.Field2, _ => dto.Field2)
                .SetProperty(x => x.Field3, _ => dto.Field3)
                .SetProperty(x => x.Field4, _ => dto.Field4)
                .SetProperty(x => x.Field5, _ => dto.Field5)
                .SetProperty(x => x.Field6, _ => dto.Field6)
                .SetProperty(x => x.Field7, _ => dto.Field7)
                .SetProperty(x => x.Field8, _ => dto.Field8)
                .SetProperty(x => x.Field9, _ => dto.Field9)
                .SetProperty(x => x.Field10, _ => dto.Field10)
                .SetProperty(x => x.Field11, _ => dto.Field11)
                .SetProperty(x => x.Field12, _ => dto.Field12)
                .SetProperty(x => x.Field13, _ => dto.Field13)
                .SetProperty(x => x.Field14, _ => dto.Field14)
                .SetProperty(x => x.Field15, _ => dto.Field15));
    }

    public async Task MultipleUpdate(InfoDto.Add dto, int count)
    {
        var lst = await Context.Set<Info>()
            .OrderBy(x => x.Field2)
            .Take(count)
            .ToListAsync();

        foreach (var x in lst)
            dto.Adapt(x);

        await Context.SaveChangesAsync();
    }

    public async Task MultipleExecuteUpdate(InfoDto.Add dto, int count)
    {
        await Context.Set<Info>()
            .OrderBy(x => x.Field2)
            .Take(count)
            .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Field1, _ => dto.Field1)
                .SetProperty(x => x.Field2, _ => dto.Field2)
                .SetProperty(x => x.Field3, _ => dto.Field3)
                .SetProperty(x => x.Field4, _ => dto.Field4)
                .SetProperty(x => x.Field5, _ => dto.Field5)
                .SetProperty(x => x.Field6, _ => dto.Field6)
                .SetProperty(x => x.Field7, _ => dto.Field7)
                .SetProperty(x => x.Field8, _ => dto.Field8)
                .SetProperty(x => x.Field9, _ => dto.Field9)
                .SetProperty(x => x.Field10, _ => dto.Field10)
                .SetProperty(x => x.Field11, _ => dto.Field11)
                .SetProperty(x => x.Field12, _ => dto.Field12)
                .SetProperty(x => x.Field13, _ => dto.Field13)
                .SetProperty(x => x.Field14, _ => dto.Field14)
                .SetProperty(x => x.Field15, _ => dto.Field15));
    }

    public async Task SingleExecuteDelete(Guid id)
    {
        await Context.Set<Info>()
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task MultipleDelete(int count)
    {
        var lst = await Context.Set<Info>()
            .OrderBy(x => x.Field2)
            .Take(count)
            .ToListAsync();

        Context.Set<Info>().RemoveRange(lst);

        await Context.SaveChangesAsync();
    }

    public async Task MultipleExecuteDelete(int count)
    {
        await Context.Set<Info>()
            .OrderBy(x => x.Field2)
            .Take(count)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<T>> MultipleSelect<T>(int count)
    {
        return await Context.Set<Info>()
            .OrderBy(x => x.Field2)
            .Take(count)
            .ProjectToType<T>()
            .ToListAsync();

    }
}
