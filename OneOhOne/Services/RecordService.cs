using System.Collections.Generic;
using OneOhOne.Dtos;
using OneOhOne.Repositories;

namespace OneOhOne.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class RecordService : IRecordService
    {

        private readonly IRecordRepository _repository;

        public RecordService() : this(new RecordRepository()) { }

        public RecordService(IRecordRepository recordRepository)
        {
            _repository = recordRepository;
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public void Delete(RecordDto dto)
        {
            Delete(dto.Id);
        }

        public List<RecordDto> FindAll()
        {
            return _repository.FindAll()
                .ConvertAll(r => new RecordDto(r));
        }

        public RecordDto FindOne(long id)
        {
            return new RecordDto(_repository.FindOne(id));
        }

        public RecordDto Save(RecordDto dto)
        {
            return new RecordDto(_repository.Save(dto.AsRecord()));
        }
    }
}