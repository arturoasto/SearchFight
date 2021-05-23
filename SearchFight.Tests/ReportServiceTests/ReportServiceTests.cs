using FluentAssertions;
using NUnit.Framework;
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
            ReportService = new ReportService(ReportServiceTestSupport.GetSearchEngines());            
        }

        [Test]
        public void ReportService_AppendResultsByArgument_ReportOutputOk()
        {
            var arguments = new string[2] { "java", "net" };
            ReportService.AppendResultsByArgument(arguments);
            ReportService.ReportOutputs.Should().NotBeEmpty();
        }

        [Test]
        public void ReportService_AppendResultsByArgument_ArgumentException()
        {
            string[] arguments = Array.Empty<string>();

            Assert.Throws<ArgumentException>(() =>
                                            ReportService.AppendResultsByArgument(arguments),                
                                            "You should provide words to start the search");
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
    }
}