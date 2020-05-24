using SearchFight.SearchEngines;
using System.Threading.Tasks;

namespace SearchFight.Tests.Mock
{
    internal class MockedSearchEngine : Base, ISearchEngine
    {
        public Task<long> GetSearchResultCount(string searchInput)
        {
            return Task.Run(() => { return long.MaxValue; });
        }

        protected override string GetSearchRequest(string searchInput)
        {
            return null;
        }
    }
}