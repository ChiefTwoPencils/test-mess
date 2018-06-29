using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneOhOne.Dtos;
using System;
using System.Diagnostics;

namespace OneOhOne.ApiControllers.Tests
{
    [TestClass()]
    public class RecordControllerTests
    {
        /// <summary>
        /// Context for getting info about the currently
        /// running unit test. Use this to avoid hard-
        /// coded literal strings; for example, unit test
        /// name. This is automatically set by th framework.
        /// </summary>
        public TestContext TestContext { get; set; }

        // Controller under test.
        RecordController _controller;

        /// <summary>
        /// Used to initialize the entire test assembly.
        /// This method will run exactly once at the start
        /// of the tests for this assembly.
        /// </summary>
        /// <param name="testContext">Same context as above.</param>
        [AssemblyInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            Trace.WriteLine($"Starting {nameof(RecordControllerTests)}...");
        }

        /// <summary>
        /// Used to initialize each unit test.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Trace.WriteLine($"Starting {TestContext.TestName}...");
        }

        /// <summary>
        /// Used to clean up after each unit test.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            Trace.WriteLine($"Cleaning up {TestContext.TestName}...");
        }

        /// <summary>
        /// Used to clean up after all tests in the assembly have 
        /// finished.
        /// </summary>
        [AssemblyCleanup]
        public static void CleanupClass()
        {
            Trace.WriteLine($"Cleaning up {nameof(RecordControllerTests)}...");
        }

        /// <summary>
        /// Example defaulting to production dependencies. A default
        /// implementation will be used for the service and the service
        /// will use the default implementation of the repo.
        /// </summary>
        [TestMethod()]
        public void GetByIdTest()
        {
            _controller = new RecordController();
            var dto = _controller.GetById(0);
            Assert.IsInstanceOfType(dto, typeof(RecordDto));
            Assert.AreEqual(0, dto.Id);
        }

        #region Examples showing cons to using try/catch-es in tests
        /// <summary>
        /// Example using a faked service, no try, with an expected
        /// exception. Shows a positive test while the code "fails";
        /// the test passes because the correct exception was thrown.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteRecordTest()
        {
            var service = new Services.Fakes.StubIRecordService()
            {
                // No matter what we send into the controller, the
                // service throws the exception without using a repo.
                DeleteRecordDto = dto => { throw new ArgumentNullException(); }
            };
            _controller = new RecordController(service);
            _controller.DeleteRecord(new RecordDto());
        }

        /// <summary>
        /// Example using a faked sevice, no try, no expected exception
        /// declared. This shows a negative test while getting the most
        /// out of the actual exception thrown. We don't trap the
        /// unexpected exception allowing for a full, interactive, stack
        /// trace from the framework.
        /// </summary>
        [TestMethod()]
        public void DeleteRecordTestNoExpect()
        {
            var service = new Services.Fakes.StubIRecordService()
            {
                DeleteRecordDto = dto => { throw new ArgumentNullException(); }
            };
            _controller = new RecordController(service);
            _controller.DeleteRecord(new RecordDto());
        }

        /// <summary>
        /// Example using a faked service, a try, and no expected exception
        /// defined. Expecting it wouldn't matter thow because we trap that
        /// and Assert.Fail throws a different exception; so the test fails
        /// anyway. We also get a minimal stack trace that starts at the
        /// assert call thereby losing all valuable information needed to 
        /// debug and fix the issue. Additionally, the catch catches EVERY
        /// possible exception making exceptions we'd want to see unable
        /// to bubble up. (think NullReferenceException)
        /// </summary>
        [TestMethod()]
        public void DeleteRecordTestNoExpectTry()
        {
            try
            {
                var service = new Services.Fakes.StubIRecordService()
                {
                    DeleteRecordDto = dto => { throw new ArgumentNullException(); }
                };
                _controller = new RecordController(service);
                _controller.DeleteRecord(new RecordDto());
            }
            catch(Exception e)
            {
                // Fail throws a custom exception
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        /// Example using a faked service, a try, no expected exception,
        /// and a Assert failure in the test body. Here, the Assert is 
        /// trapped in the catch, and another - different - exception is
        /// thrown thereby losing all valuable information about what
        /// caused the test failure like above.
        /// </summary>
        [TestMethod()]
        public void DeleteRecordTestNoExpectTryEqual()
        {
            try
            {
                var service = new Services.Fakes.StubIRecordService()
                {
                    DeleteRecordDto = dto => { return; }
                };
                _controller = new RecordController(service);
                _controller.DeleteRecord(new RecordDto());
                Assert.AreEqual("", " ");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        /// A repeat example from above showing mocking has no role in the outcome.
        /// </summary>
        [TestMethod()]
        public void DeleteRecordTestNoExpectTryNoMock()
        {
            try
            {
                _controller = new RecordController();
                _controller.DeleteRecord(new RecordDto());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        /// A repeat example from above showing mocking has no role in the outcome.
        /// </summary>
        [TestMethod()]
        public void DeleteRecordTestNoExpectNoMock()
        {
            _controller = new RecordController();
            _controller.DeleteRecord(new RecordDto());
        }

        /// <summary>
        /// A repeat example from above showing the problem with accepting
        /// the try/catch pattern in tests while dealing with the lost 
        /// information. There's no interactive stack trace provided as that
        /// starts with the call to Assert.Fail and the output is harder to
        /// read and needs to be manually traced.
        /// </summary>
        [TestMethod()]
        public void DeleteRecordTestNoExpectTryNoMockTraced()
        {
            try
            {
                _controller = new RecordController();
                _controller.DeleteRecord(new RecordDto());
            }
            catch (Exception e)
            {
                Assert.Fail($"{e.Message}\n{e.StackTrace}");
            }
        }
        #endregion no try/catch-es
    }
}