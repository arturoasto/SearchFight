using Bogus;
using FluentAssertions;
using NUnit.Framework;
using SearchFight.SearchEngines;
using SearchFight.Tests.ReportServiceTests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight.Tests
{
    public class SearchEngineTests
    {
        [Test]
        public void SearchEngine_Google_GetSearchResultCount()
        {
            var faker = new Faker();
            var reportService = new ReportService(ReportServiceTestSupport.GetSearchEngines());            
            var result = reportService.SearchEngines.First().GetSearchResultCount(faker.Random.String());

            result.Should().BeGreaterOrEqualTo(0);
        }

        [Test]
        public void SearchEngine_SetBingSearch_HeaderIsPresent()
        {
            var engine = new SearchEngine();
            engine.SetBingSearch("test");

            var isHeaderPresent = engine.Client.DefaultRequestHeaders.Contains("Ocp-Apim-Subscription-Key");
            isHeaderPresent.Should().BeTrue();
        }

        [Test]
        public void SearchEngine_SetMaxResults_Ok()
        {
            var faker = new Faker();
            var engine = new SearchEngine();

            engine.SetMaxResults(faker.Random.Long(1), faker.Random.String());

            engine.MaxResult.Should().NotBe(0);
            engine.MaxWinner.Should().NotBe(string.Empty);
        }

        [Test]
        public void SearchEngine_SetBingSearch_ApiKeyEmpty()
        {
            var engine = new SearchEngine();
            var exception = new ArgumentException("Api key should not be empty");

            var result = Assert.Throws<ArgumentException>(() => engine.SetBingSearch(string.Empty));
            Assert.AreEqual(exception.Message, result.Message);
        }

        [Test]
        public void SearchEngine_SearchResult_SearchRequestEmpty()
        {
            var engine = new SearchEngine();
            var exception = new ArgumentException("Search request should not be empty");

            var result = Assert.Throws<ArgumentException>(() => engine.SearchResult(string.Empty));
            Assert.AreEqual(exception.Message, result.Message);
        }
    }
}
