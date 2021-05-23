using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight.SearchEngines
{
    public abstract class SearchEngine
    {
        public SearchEngineType Name { get; set; }
        public long MaxResult { get; set; }
        public string MaxWinner { get; set; }

        public HttpClient Client { get; set; }
        public static string GetConfiguration(string key) => ConfigurationManager.AppSettings[key];
        protected abstract string GetSearchRequest(string searchInput);

        protected static string SearchResult(HttpClient client, string searchRequest)
        {            
            var response = client.GetAsync(searchRequest).GetAwaiter().GetResult();
            using var reader = new StreamReader(response.Content.ReadAsStream());
            return reader.ReadToEnd();
        }

        protected void SetMaxResults(long result, string searchInput)
        {
            if (result > MaxResult)
            {
                MaxResult = result;
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