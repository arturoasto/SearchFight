using Bogus;
using SearchFight.SearchEngines;

namespace SearchFight.Tests.Mock
{
    internal class MockedSearchEngine : ISearchEngine
    {
        public SearchEngineType Name { get; set; }
        public SearchEngine Engine { get ; set ; }

        public long GetSearchResultCount(string searchInput)
        {
            var faker = new Faker();
            return faker.Random.Long(0);
        }
    }
}