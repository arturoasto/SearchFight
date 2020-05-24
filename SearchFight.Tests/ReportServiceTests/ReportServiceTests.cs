using FluentAssertions;
using NUnit.Framework;
using SearchFight.Tests.Mock;
using System;
using System.Linq;

namespace SearchFight.Tests.ReportServiceTests
{
    public class ReportServiceTests
    {
        private MockedSearchEngine MockedSearchEngine;
        private ReportService ReportService;
        private ReportServiceTestSupport ReportServiceTestSupport;

        [SetUp]
        public void Setup()
        {
            MockedSearchEngine = new MockedSearchEngine();
            ReportServiceTestSupport = new ReportServiceTestSupport();
            ReportService = new ReportService(ReportServiceTestSupport.GetSearchEngines());            
        }

        [Test]
        public void ReportService_AppendResultsByArgument_ReportOutputOk()
        {
            var arguments = new string[2] { "java", "net" };
            ReportService.AppendResultsByArgument(arguments).GetAwaiter().GetResult();
            ReportService.ReportOutputs.Should().NotBeEmpty();
        }

        [Test]
        public void ReportService_AppendResultsByArgument_ArgumentException()
        {
            string[] arguments = new string[0];

            Assert.Throws<ArgumentException>(() =>
                                            ReportService.AppendResultsByArgument(arguments).GetAwaiter().GetResult(),                
                                            "You should provide words to start the search");
        }

        [Test]
        public void ReportService_AppendResultsBySearchEngine_Success()
        {
            ReportService.AppendResultsBySearchEngine();
            ReportService.ReportOutputs.First()
                                       .Should()
                                       .Be($"{MockedSearchEngine.Name} winner: {MockedSearchEngine.MaxWinner}");
        }

        [Test]
        public void ReportService_AppendTotalWinner_Success()
        {
            ReportService.AppendTotalWinner();
            ReportService.ReportOutputs.First()
                                       .Should()
                                       .Be($"Total winner: {MockedSearchEngine.MaxWinner}");
        }
    }
}