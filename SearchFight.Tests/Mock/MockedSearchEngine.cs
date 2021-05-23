using Bogus;
using SearchFight.SearchEngines;
using SearchFight.SearchEngines.Interfaces;

namespace SearchFight.Tests.Mock
{
    internal class MockedSearchEngine : ICustomSearchEngine
    {
        public SearchEngineType Name { get; set; }
        public ISearchEngine Engine { get ; set ; }

        public long GetSearchResultCount(string searchInput)
        {
            var faker = new Faker();
            var resultNumber = faker.Random.Long(0);
            Engine.SetMaxResults(resultNumber, searchInput);
            return resultNumber;
        }

        public MockedSearchEngine(ISearchEngine searchEngine)
        {
            Engine = searchEngine;
        }
    }
}