using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneOhOne.ApiControllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOhOne.ApiControllers.Tests
{
    [TestClass()]
    public class RecordControllerTests
    {
        public TestContext TestContext { get; set; }

        RecordController _controller;

        [AssemblyInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            Trace.WriteLine($"Starting {nameof(RecordControllerTests)}...");
        }

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

        [AssemblyCleanup]
        public static void CleanupClass()
        {
            Trace.WriteLine($"Cleaning up {nameof(RecordControllerTests)}...");
        }

        [TestMethod()]
        public void GetByIdTest()
        {

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteRecordTest()
        {
            var repo = new Fakes.ShimRecordService()
            {

            }
        }
    }
}