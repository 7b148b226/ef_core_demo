using ef_core_7_with_.net_7.DTO;
using ef_core_7_with_.net_7.Static;

namespace ef_core_7_with_.net_7.BLL;

public sealed class TestInfoService
{
    private InfoService InfoService { get; }

    public TestInfoService(InfoService infoService)
    {
        InfoService = infoService;
    }

    public async Task SingleInsert()
    {
        var id = await InfoService.Add(Build<InfoDto.Add>());
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
        await InfoService.MultipleInsert(Build<InfoDto.Add>(), count);
    }

    public async Task BulkInsert(int count)
    {
        await InfoService.BulkInsert(Build<InfoDto.Add>(), count);
    }

    public async Task SingleUpdate(Guid id)
    {
        var dto = Build<InfoDto.Edit>() with { Id = id, };
        await InfoService.Edit(dto);
    }

    public async Task SingleExecuteUpdate(Guid id)
    {
        var dto = Build<InfoDto.Edit>() with { Id = id };
        await InfoService.SingleExecuteUpdate(dto);
    }

    public async Task MultipleUpdate(int count)
    {
        await InfoService.MultipleUpdate(Build<InfoDto.Add>(), count);
    }

    public async Task MultipleExecuteUpdate(int count)
    {
        var dto = Build<InfoDto.Add>();
        await InfoService.MultipleExecuteUpdate(dto, count);
    }

    public async Task SingleDelete(Guid id)
    {
        await InfoService.Delete(id);
    }

    public async Task SingleExecuteDelete(Guid id)
    {
        await InfoService.SingleExecuteDelete(id);
    }

    public async Task MultipleDelete(int count)
    {
        await InfoService.MultipleDelete(count);
    }

    public async Task MultipleExecuteDelete(int count)
    {
        await InfoService.MultipleExecuteDelete(count);
    }

    public async Task SingleQuery(Guid id)
    {
        var dto = await InfoService.ById<InfoDto.ById>(id);
    }

    public async Task MultipleQuery(int count)
    {
        var lst = await InfoService.MultipleSelect<InfoDto.List>(count);
    }
}
