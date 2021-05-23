using Newtonsoft.Json;
using SearchFight.Models.Bing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;

namespace SearchFight.SearchEngines
{
    public class BingSearch : ISearchEngine
    {
        private static string BaseUrl => GetConfiguration("BING_BASE_URL");
        private static string ApiKey => GetConfiguration("BING_API_KEY");

        public SearchEngine Engine { get; set; }

        public SearchEngineType Name { get; set; }

        public long MaxResult { get; set; }
        public string MaxWinner { get; set; }

        public BingSearch()
        {
            Name = SearchEngineType.Bing;
            Engine = new SearchEngine();
            Engine.SetBingSearch(ApiKey);
        }

        public static string GetConfiguration(string key) => ConfigurationManager.AppSettings[key];

        public long GetSearchResultCount(string searchInput)
        {
            string content = Engine.SearchResult(GetSearchRequest(searchInput));

            var bingResponse = JsonConvert.DeserializeObject<BingResponse>(content);
            var searchTotalResults = long.Parse(bingResponse.WebPages.TotalEstimatedMatches);

            (MaxResult, MaxWinner) = SearchEngine.SetMaxResults(searchTotalResults, MaxResult, MaxWinner, searchInput);

            return searchTotalResults;
        }

        private static string GetSearchRequest(string searchInput)
        {
            return BaseUrl.Replace("{KEY}", ApiKey)
                          .Replace("{QUERY}", searchInput);
        }
    }
}
