using OneOhOne.Models;
using System.Collections.Generic;
using System.Linq;

namespace OneOhOne.Repositories
{
    public interface IRecordRepository
    {
        List<Record> FindAll();
        Record FindOne(long id);
        Record Save(Record record);
        void Delete(Record record);
        void Delete(long id);
    }
}
