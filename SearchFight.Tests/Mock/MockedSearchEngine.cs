using SearchFight.SearchEngines;
using System.Threading.Tasks;

namespace SearchFight.Tests.Mock
{
    internal class MockedSearchEngine : ISearchEngine
    {
        public string Name { get; } = "Mocked Searcher";

        public long MaxResult { get; set; }
        public string MaxWinner { get; set; }

        public Task<long> GetSearchResultCount(string searchInput)
        {
            return Task.Run(() => { return long.MaxValue; });
        }
    }
}