using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ef_6_with_.net_4.DAL;
using ef_6_with_.net_4.DAL.Entities;
using ef_6_with_.net_4.DTO;
using Mapster;

namespace ef_6_with_.net_4.BLL
{
    public sealed class InfoService : EntityService<Info, Guid>
    {
        public InfoService(AppDbContext context) : base(context) { }

        public async Task MultipleInsert(InfoDto.Add dto, int count, TypeAdapterConfig cnf)
        {
            for (var _ = 0; _ < count; ++_)
                Context.Set<Info>().Add(dto.Adapt<Info>(cnf));

            await Context.SaveChangesAsync();
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

        public async Task MultipleDelete(int count)
        {
            var lst = await Context.Set<Info>()
                .OrderBy(x => x.Field2)
                .Take(count)
                .ToListAsync();

            Context.Set<Info>().RemoveRange(lst);

            await Context.SaveChangesAsync();
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
}
