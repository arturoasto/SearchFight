using SearchFight.SearchEngines;

namespace SearchFight.Tests.Mock
{
    internal class MockedSearchEngine : ISearchEngine
    {
        public SearchEngineType Name { get; set; }

        public long MaxResult { get; set; }
        public string MaxWinner { get; set; }

        public long GetSearchResultCount(string searchInput)
        {
            return long.MaxValue;
        }
    }
}