namespace SearchFight.SearchEngines
{
    public interface ISearchEngine
    {
        public string Name { get; }
        public int MaxResult { get; set; }
        public string MaxWinner { get; set; }
        public int GetSearchResultCount(string searchInput);
    }
}
