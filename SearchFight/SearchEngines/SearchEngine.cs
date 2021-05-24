using SearchFight.SearchEngines.Interfaces;
using System;
using System.Net.Http;

namespace SearchFight.SearchEngines
{
    public class SearchEngine : ISearchEngine
    {
        public HttpClient Client { get; set; }
        public long MaxResult { get; set; }
        public string MaxWinner { get; set; }

        public SearchEngine()
        {
            Client = new HttpClient();
        }

        public void AddCustomHeader(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"the name value should not be empty");
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException($"the key value should not be empty");

            Client.DefaultRequestHeaders.Add(name, value);
        }

        public string SearchResult(string searchRequest)
        {
            if (string.IsNullOrWhiteSpace(searchRequest)) throw new ArgumentException("Search request should not be empty");
            if (Client == null) throw new ArgumentException("httpClient should not be null");

            var response = Client.GetAsync(searchRequest).GetAwaiter().GetResult();
            var jsonResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return jsonResult;
        }        

        public void SetMaxResults(long newResult, string searchInput)
        {
            if (newResult > MaxResult)
            {
                MaxResult = newResult;
                MaxWinner = searchInput;
            }
        }
    }

    public enum SearchEngineType
    {
        Google,
        Bing
    }
}