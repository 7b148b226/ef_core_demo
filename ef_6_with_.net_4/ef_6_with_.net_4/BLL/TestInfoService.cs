using System;
using System.Threading.Tasks;
using ef_6_with_.net_4.DAL;
using ef_6_with_.net_4.DAL.Entities;
using ef_6_with_.net_4.DTO;
using ef_6_with_.net_4.Static;
using Mapster;

namespace ef_6_with_.net_4.BLL
{
    public sealed class TestInfoService
    {
        private InfoService InfoService { get; }

        public TestInfoService()
        {
            InfoService = new InfoService(new AppDbContext());
        }

        public async Task SingleInsert()
        {
            await InfoService.Add(Build<InfoDto.Add>(), Config());
        }

        private TypeAdapterConfig Config()
        {
            var cnf = new TypeAdapterConfig();
            cnf.NewConfig<InfoDto.Add, Info>()
                .Map(x => x.Id, _ => Guid.NewGuid());

            return cnf;
        }

        private T Build<T>() where T : InfoDto.IInfo, new()
        {
            return new T
            {
                Field1 = RandomString.AlphaNumeric(4),
                Field2 = RandomString.AlphaNumeric(64),
                Field3 = RandomString.AlphaNumeric(1024),
                Field4 = RandomString.AlphaNumeric(4000),
                Field5 = RandomString.AlphaNumeric(10000),
                Field6 = RandomNumber.Bool(),
                Field7 = RandomNumber.Byte(),
                Field8 = RandomNumber.Short(),
                Field9 = RandomNumber.Int(),
                Field10 = RandomNumber.Long(),
                Field11 = RandomNumber.Decimal(4, 2),
                Field12 = RandomNumber.Decimal(9, 5),
                Field13 = RandomNumber.Decimal(19, 10),
                Field14 = RandomNumber.Decimal(29, 19),
                Field15 = RandomDateTime.Minutes(),
            };
        }

        public async Task MultipleInsert(int count)
        {
            await InfoService.MultipleInsert(Build<InfoDto.Add>(), count, Config());
        }

        public async Task SingleUpdate(Guid id)
        {
            var dto = Build<InfoDto.Edit>();
            dto.Id = id;
            await InfoService.Edit(dto);
        }

        public async Task MultipleUpdate(int count)
        {
            await InfoService.MultipleUpdate(Build<InfoDto.Add>(), count);
        }

        public async Task SingleDelete(Guid id)
        {
            await InfoService.Delete(id);
        }

        public async Task MultipleDelete(int count)
        {
            await InfoService.MultipleDelete(count);
        }

        public async Task SingleQuery(Guid id)
        {
            await InfoService.ById<InfoDto.ById>(id);
        }

        public async Task MultipleQuery(int count)
        {
            await InfoService.MultipleSelect<InfoDto.List>(count);
        }
    }
}
