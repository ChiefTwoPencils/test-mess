using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace OneOhOne.Repositories.Tests
{
    [TestClass()]
    public class RecordRepositoryTests
    {
        public TestContext TestContext { get; set; }

        RecordRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            Trace.WriteLine($"Starting {TestContext.TestName}...");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Trace.WriteLine($"Cleaning up {TestContext.TestName}...");
        }

        [TestMethod()]
        public void DeleteTest()
        {
            _repository.Delete(null);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            throw new ArgumentNullException();
        }

        [TestMethod()]
        public void FindAllTest()
        {
            Trace.WriteLine("Assert find all...");
        }

        [TestMethod()]
        public void FindOneTest()
        {
            Trace.WriteLine("Assert find one...");
        }

        [TestMethod()]
        public void SaveTest()
        {
            Trace.WriteLine("Assert save...");
        }
    }
}