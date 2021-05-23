namespace SearchFight.SearchEngines
{
    public interface ISearchEngine
    {
        SearchEngineType Name { get; }
        long MaxResult { get; set; }
        string MaxWinner { get; set; }
        long GetSearchResultCount(string searchInput);
    }
}
