using System.Configuration;
using System.IO;
using System.Net.Http;

namespace SearchFight.SearchEngines
{
    public class SearchEngine
    {
        public HttpClient Client { get; set; }

        public SearchEngine()
        {
            Client = new HttpClient();
        }

        public void SetBingSearch(string apiKey)
        {
            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
        }        

        public string SearchResult(string searchRequest)
        {            
            var response = Client.GetAsync(searchRequest).GetAwaiter().GetResult();
            using var reader = new StreamReader(response.Content.ReadAsStream());
            return reader.ReadToEnd();
        }

        public static (long, string) SetMaxResults(long newResult, long currentResult, string currentWinner, string searchInput)
        {
            if (newResult > currentResult)
            {
                currentResult = newResult;
                currentWinner = searchInput;
            }

            return (currentResult, currentWinner);
        }
    }

    public enum SearchEngineType
    {
        Google,
        Bing
    }
}