using System;
using System.Threading.Tasks;
using System.Web.Http;
using ef_6_with_.net_4.BLL;

namespace ef_6_with_.net_4.Controllers
{
    [RoutePrefix("api/tests")]
    public class TestsController : ApiController
    {
        private TestInfoService TestInfoService { get; }

        private int Count { get; }

        public TestsController()
        {
            TestInfoService = new TestInfoService();
            Count = 1000;
        }

        [HttpPost]
        [Route("single-insert")]
        public async Task SingleInsert()
        {
            await TestInfoService.SingleInsert();
        }

        [HttpPost]
        [Route("multiple-insert")]
        public async Task MultipleInsert()
        {
            await TestInfoService.MultipleInsert(Count);
        }

        [HttpPut]
        [Route("single-update/{id:guid}")]
        public async Task SingleUpdate(Guid id)
        {
            await TestInfoService.SingleUpdate(id);
        }

        [HttpPut]
        [Route("multiple-update")]
        public async Task MultipleUpdate()
        {
            await TestInfoService.MultipleUpdate(Count);
        }

        [HttpDelete]
        [Route("single-delete/{id:guid}")]
        public async Task SingleDelete(Guid id)
        {
            await TestInfoService.SingleDelete(id);
        }

        [HttpDelete]
        [Route("multiple-delete")]
        public async Task MultipleDelete()
        {
            await TestInfoService.MultipleDelete(Count);
        }

        [HttpGet]
        [Route("single-query/{id:guid}")]
        public async Task SingleQuery(Guid id)
        {
            await TestInfoService.SingleQuery(id);
        }

        [HttpGet]
        [Route("multiple-query")]
        public async Task MultipleQuery()
        {
            await TestInfoService.MultipleQuery(Count);
        }
    }
}
