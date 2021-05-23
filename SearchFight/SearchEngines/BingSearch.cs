using Newtonsoft.Json;
using SearchFight.Models.Bing;
using System.Configuration;

namespace SearchFight.SearchEngines
{
    public class BingSearch : ISearchEngine
    {
        private static string BaseUrl => ConfigurationManager.AppSettings["BING_BASE_URL"];
        private static string ApiKey => ConfigurationManager.AppSettings["BING_API_KEY"];

        public SearchEngine Engine { get; set; }
        public SearchEngineType Name { get; set; }

        public BingSearch()
        {
            Name = SearchEngineType.Bing;
            Engine = new SearchEngine();
            Engine.SetBingSearch(ApiKey);
        }

        public long GetSearchResultCount(string searchInput)
        {
            string content = Engine.SearchResult(GetSearchRequest(searchInput));

            var bingResponse = JsonConvert.DeserializeObject<BingResponse>(content);
            var searchTotalResults = long.Parse(bingResponse.WebPages.TotalEstimatedMatches);

            Engine.SetMaxResults(searchTotalResults, searchInput);

            return searchTotalResults;
        }

        private static string GetSearchRequest(string searchInput)
        {
            return BaseUrl.Replace("{KEY}", ApiKey)
                          .Replace("{QUERY}", searchInput);
        }
    }
}
