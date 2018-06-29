using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OneOhOne.Models;

namespace OneOhOne.Repositories
{
    /// <summary>
    /// A repo class that implements the common interface
    /// to all repositories; basic CRUDL opertations. It's
    /// crucial to implement the common interface so the
    /// repo can be faked while components that depend on
    /// it can be tested.
    /// </summary>
    public class RecordRepository : IRecordRepository
    {
        /// <summary>
        /// Used for testing purposes. Shows that when we exceptions
        /// to bubble up and fail tests naturally, we can get detailed
        /// and valuable information for debugging and resolving issues.
        /// </summary>
        /// <param name="id"></param>
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