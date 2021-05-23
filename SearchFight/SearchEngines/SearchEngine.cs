using System;
using System.IO;
using System.Net.Http;

namespace SearchFight.SearchEngines
{
    public class SearchEngine
    {
        public HttpClient Client { get; set; }
        public long MaxResult { get; set; }
        public string MaxWinner { get; set; }

        public SearchEngine()
        {
            Client = new HttpClient();
        }

        public void SetBingSearch(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentException("Api key should not be empty");

            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
        }

        public string SearchResult(string searchRequest)
        {
            if (string.IsNullOrWhiteSpace(searchRequest)) throw new ArgumentException("Search request should not be empty");

            var response = Client.GetAsync(searchRequest).GetAwaiter().GetResult();
            using var reader = new StreamReader(response.Content.ReadAsStream());
            return reader.ReadToEnd();
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