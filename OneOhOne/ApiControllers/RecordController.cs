using OneOhOne.Dtos;
using OneOhOne.Services;
using System.Web.Http;

namespace OneOhOne.ApiControllers
{
    public class RecordController : ApiController
    {
        private readonly IRecordService _service;

        public RecordController() : this(new RecordService()) { }

        public RecordController(IRecordService recordService)
        {
            _service = recordService;
        }

        [HttpGet]
        [Route("records/{id}")]
        public RecordDto GetById(long id)
        {
            return _service.FindOne(id);
        }

        [HttpDelete]
        [Route("records")]
        public bool DeleteRecord(RecordDto dto)
        {
            _service.Delete(dto);
            return true;
        }
    }
}
