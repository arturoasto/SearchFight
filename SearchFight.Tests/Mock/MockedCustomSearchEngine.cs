using Bogus;
using SearchFight.SearchEngines;
using SearchFight.SearchEngines.Interfaces;
using System.Net.Http;

namespace SearchFight.Tests.Mock
{
    internal class MockedCustomSearchEngine : ICustomSearchEngine
    {
        public SearchEngineType Name { get; set; }
        public ISearchEngine Engine { get ; set ; }
        public HttpClient Client { get; set; }

        public long GetSearchResultCount(string searchInput)
        {
            var faker = new Faker();
            var resultNumber = faker.Random.Long(0);
            Engine.SetMaxResults(resultNumber, searchInput);
            return resultNumber;
        }

        public MockedCustomSearchEngine(ISearchEngine searchEngine)
        {
            Engine = searchEngine;
        }
    }
}