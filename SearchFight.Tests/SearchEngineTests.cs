using Bogus;
using FluentAssertions;
using NUnit.Framework;
using SearchFight.SearchEngines;
using SearchFight.Tests.Mock;
using SearchFight.Tests.ReportServiceTests;
using System;
using System.Linq;

namespace SearchFight.Tests
{
    public class SearchEngineTests
    {
        [Test]
        public void SearchEngine_Google_GetSearchResultCount()
        {
            var faker = new Faker();
            var reportService = new ReportService(ReportServiceTestSupport.GetSearchEngines(ReportServiceTestSupport.GetCustomSearchEngineDefault()));            
            var result = reportService.SearchEngines.First().GetSearchResultCount(faker.Random.String());

            result.Should().BeGreaterOrEqualTo(0);
        }

        [Test]
        public void SearchEngine_AddCustomHeader_HeaderIsPresent()
        {
            var engine = new SearchEngine();
            engine.AddCustomHeader("test","testValue");

            var isHeaderPresent = engine.Client.DefaultRequestHeaders.Contains("test");
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
        public void SearchEngine_AddCustomHeader_NameValueEmpty()
        {
            var engine = new SearchEngine();
            var exception = new ArgumentException("the name value should not be empty");

            var result = Assert.Throws<ArgumentException>(() => engine.AddCustomHeader(string.Empty, new Faker().Random.String()));
            Assert.AreEqual(exception.Message, result.Message);
        }

        [Test]
        public void SearchEngine_AddCustomHeader_ValueKeyEmpty()
        {
            var engine = new SearchEngine();
            var exception = new ArgumentException("the key value should not be empty");

            var result = Assert.Throws<ArgumentException>(() => engine.AddCustomHeader(new Faker().Random.String(), string.Empty));
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

        [Test]
        public void SearchEngine_SearchResult_HttpClientIsNull()
        {
            var engine = new SearchEngine();
            engine.Client = null;
            var exception = new ArgumentException("httpClient should not be null");

            var result = Assert.Throws<ArgumentException>(() => engine.SearchResult(new Faker().Random.String()));
            Assert.AreEqual(exception.Message, result.Message);
        }

        [Test]
        public void Google_SearchResultCount_Ok()
        {
            GoogleSearch googleSearch= new(new MockedGoogleSearchEngine());

            var result = googleSearch.GetSearchResultCount(new Faker().Random.String());
            result.Should().Be(100);
        }

        [Test]
        public void Google_GetSearchRequest_NullException()
        {
            Assert.Throws<ArgumentNullException>(() => GoogleSearch.GetSearchRequest(null));
        }

        [Test]
        public void Bing_SearchResultCount_Ok()
        {
            BingSearch bingSearch = new(new MockedBingSearchEngine());

            var result = bingSearch.GetSearchResultCount(new Faker().Random.String());
            result.Should().Be(100);
        }

        [Test]
        public void Bing_GetSearchRequest_NullException()
        {
            Assert.Throws<ArgumentNullException>(() => BingSearch.GetSearchRequest(null));
        }
    }
}
