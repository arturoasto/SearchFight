using System.Net.Http;

namespace SearchFight.SearchEngines.Interfaces
{
    public interface ISearchEngine
    {
        HttpClient Client { get; set; }
        long MaxResult { get; set; }
        string MaxWinner { get; set; }
        void SetBingSearch(string apiKey);
        string SearchResult(string searchRequest);
        void SetMaxResults(long newResult, string searchInput);
    }
}
