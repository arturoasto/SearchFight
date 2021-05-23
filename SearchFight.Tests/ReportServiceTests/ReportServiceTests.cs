using FluentAssertions;
using NUnit.Framework;
using SearchFight.SearchEngines;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight.Tests.ReportServiceTests
{
    public class ReportServiceTests
    {
        private ReportService ReportService;

        [SetUp]
        public void Setup()
        {
            ReportService = new ReportService(ReportServiceTestSupport.GetSearchEngines(ReportServiceTestSupport.GetCustomSearchEngineDefault()));            
        }

        [Test]
        public void ReportService_LoadReport()
        {
            var reportService = new ReportService(ReportServiceTestSupport.GetSearchEngines(ReportServiceTestSupport.GetCustomSearchEngineEmpty()));

            reportService.LoadReport(new[] { "java", "net"});
            reportService.ReportOutputs.Count().Should().Be(5);
        }

        [Test]
        public void GetSupportedSearchEngines_Ok()
        {
            ReportService.SearchEngines.Count.Should().Be(2);
            ReportService.SearchEngines.Select(x => x.Name).Should().BeEquivalentTo(Enum.GetValues(typeof(SearchEngineType)));
        }

        [Test]
        public void ReportService_AppendResultsByArgument_ReportOutputOk()
        {
            var arguments = new string[2] { "java", "net" };
            ReportService.AppendResultsByArgument(arguments);
            ReportService.ReportOutputs.Should().NotBeEmpty();
        }

        [Test]
        public void ReportService_AppendResultsByArgument_ReportOutput_MoreWords_Ok()
        {
            var arguments = new string[4] { "java", "net", "c# 9", "dotnet core" };
            ReportService.AppendResultsByArgument(arguments);
            ReportService.ReportOutputs.Should().NotBeEmpty();
            ReportService.ReportOutputs.Count().Should().Be(4);
        }

        [Test]
        public void ReportService_GetReportLine_Ok()
        {
            var result = ReportService.GetReportLine("search fight");
            ReportService.ReportOutputs.Add(result);
            ReportService.ReportOutputs.Should().NotBeEmpty();
            ReportService.ReportOutputs.Count().Should().Be(1);
        }

        [Test]
        public void ReportService_AppendResultsByArgument_NullReferenceException()
        {
            ReportService.ReportOutputs = null;
            var arguments = new string[2] { "java", "net" };
            Assert.Throws<NullReferenceException>(() => ReportService.AppendResultsByArgument(arguments));
        }


        [Test]
        public void ReportService_AppendResultsByArgument_ArgumentException()
        {
            string[] arguments = Array.Empty<string>();
            var exception = new ArgumentException("You should provide words to start the search");

            var result = Assert.Throws<ArgumentException>(() => ReportService.AppendResultsByArgument(arguments));
            Assert.AreEqual(exception.Message, result.Message);
        }

        [Test]
        public void ReportService_AppendResultsBySearchEngine_Success()
        {
            ReportService.AppendResultsBySearchEngine();
            ReportService.ReportOutputs.Should().BeEquivalentTo(new List<string>()
            {
                "Google winner: search fight",
                "Bing winner: search fight"
            });
        }

        [Test]
        public void ReportService_AppendTotalWinner_Success()
        {
            ReportService.AppendTotalWinner();
            ReportService.ReportOutputs.First()
                                       .Should()
                                       .Be($"Total winner: search fight");
        }

        [Test]
        public void ReportService_AppendTotalWinner_NullReferenceException()
        {
            ReportService.SearchEngines.Clear();
            Assert.Throws<InvalidOperationException>(() => ReportService.AppendTotalWinner());
        }
    }
}