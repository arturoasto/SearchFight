using FluentAssertions;
using NUnit.Framework;
using SearchFight.SearchEngines;
using System;
using System.Collections.Generic;

namespace SearchFight.Tests
{
    public class ReportServiceTests
    {
        private ReportService ReportService;

        [SetUp]
        public void Setup()
        {
            ReportService = new ReportService(GetSearchEngines());            
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

        private List<ISearchEngine> GetSearchEngines()
        {
            return new List<ISearchEngine>()
            {
                new GoogleSearch(){}
            };
        }
    }
}