using SearchFight.SearchEngines.Interfaces;

namespace SearchFight.SearchEngines
{
    public interface ICustomSearchEngine
    {
        ISearchEngine Engine { get; set; }
        SearchEngineType Name { get; }
        long GetSearchResultCount(string searchInput);
    }
}
