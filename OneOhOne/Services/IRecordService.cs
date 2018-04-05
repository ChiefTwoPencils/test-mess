using OneOhOne.Dtos;
using System.Collections.Generic;

namespace OneOhOne.Services
{
    public interface IRecordService
    {
        List<RecordDto> FindAll();
        RecordDto FindOne(long id);
        RecordDto Save(RecordDto record);
        void Delete(RecordDto record);
        void Delete(long id);
    }
}
