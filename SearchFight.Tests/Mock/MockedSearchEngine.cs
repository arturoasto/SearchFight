using SearchFight.SearchEngines;
using System.Threading.Tasks;

namespace SearchFight.Tests.Mock
{
    internal class MockedSearchEngine : SearchEngine, ISearchEngine
    {
        public long GetSearchResultCount(string searchInput)
        {
            return long.MaxValue;
        }

        protected override string GetSearchRequest(string searchInput)
        {
            return null;
        }
    }
}