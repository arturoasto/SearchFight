using NUnit.Framework;
using System;

namespace SearchFight.Tests.ReportServiceTests
{
    public class ReportServiceTests
    {
        private ReportService ReportService;
        private ReportServiceTestSupport ReportServiceTestSupport;

        [SetUp]
        public void Setup()
        {
            ReportServiceTestSupport = new ReportServiceTestSupport();
            ReportService = new ReportService(ReportServiceTestSupport.GetSearchEngines());            
        }

        [Test]
        public void ReportService_AppendResultsByArgument_ReportOutputOk()
        {
            var arguments = new string[2] { "java", "net" };
            ReportService.AppendResultsByArgument(arguments);
            Assert.IsNotEmpty(ReportService.ReportOutputs);
        }

        [Test]
        public void ReportService_AppendResultsByArgument_ArgumentException()
        {
            string[] arguments = null;

            Assert.Throws<ArgumentException>(() => ReportService.AppendResultsByArgument(arguments), "You should provide words to start the search");
        }
    }
}