using NUnit.Framework;
using SearchFight.SearchEngines;
using System.Collections.Generic;

namespace SearchFight.Tests
{
    public class ReportServiceTests
    {
        private ReportService ReportService;
        private string[] arguments;

        [SetUp]
        public void Setup()
        {
            ReportService = new ReportService(GetSearchEngines());
            arguments = new string[2] { "java", "net" };
        }

        [Test]
        public void ReportService_AppendResultsByArgument_ReportOutputOk()
        {
            ReportService.AppendResultsByArgument(arguments);
            Assert.IsNotEmpty(ReportService.ReportOutputs);
        }

        private List<ISearchEngine> GetSearchEngines()
        {
            return new List<ISearchEngine>()
            {
                new GoogleSearch(){}
            };
        }
    }
}