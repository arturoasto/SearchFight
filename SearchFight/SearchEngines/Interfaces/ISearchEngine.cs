namespace SearchFight.SearchEngines
{
    public interface ISearchEngine
    {
        SearchEngine Engine { get; set; }
        SearchEngineType Name { get; }
        long GetSearchResultCount(string searchInput);
    }
}
