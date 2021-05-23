namespace SearchFight.SearchEngines
{
    public interface ISearchEngine
    {
        string Name { get; }
        long MaxResult { get; set; }
        string MaxWinner { get; set; }
        long GetSearchResultCount(string searchInput);
    }
}
