﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneOhOne.Dtos;
using System;
using System.Diagnostics;

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
            _controller = new RecordController();
            var dto = _controller.GetById(0);
            Assert.IsInstanceOfType(dto, typeof(RecordDto));
            Assert.AreEqual(0, dto.Id);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteRecordTest()
        {
            var service = new Services.Fakes.StubIRecordService()
            {
                DeleteRecordDto = dto => { throw new ArgumentNullException(); }
            };
            _controller = new RecordController(service);
            _controller.DeleteRecord(new RecordDto());
        }
    }
}