using OneOhOne.Dtos;
using OneOhOne.Services;
using System.Web.Http;

namespace OneOhOne.ApiControllers
{
    /// <summary>
    /// Example class that accepts a service interface for testability.
    /// No DI is involved; only an extra contructor is provided to allow
    /// tests to inject faked implementations.
    /// </summary>
    public class RecordController : ApiController
    {
        // It is crucial to program to an interface rather
        // than a concrete implementation used in production.
        private readonly IRecordService _service;

        /// <summary>
        /// Default constructor that falls back to the production service
        /// when not under test.
        /// </summary>
        public RecordController() : this(new RecordService()) { }

        /// <summary>
        /// Controller used to facilitate faked tests.
        /// </summary>
        /// <param name="recordService">The injected service.</param>
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
