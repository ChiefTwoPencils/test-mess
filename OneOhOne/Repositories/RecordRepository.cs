using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OneOhOne.Models;

namespace OneOhOne.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        public void Delete(long id)
        {
            throw new ArgumentNullException("This is probably way better!");
        }

        public void Delete(Record record)
        {
            
        }

        public List<Record> FindAll()
        {
            return new List<Record>();
        }

        public Record FindOne(long id)
        {
            return new Record();
        }

        public Record Save(Record record)
        {
            return new Record();
        }
    }
}