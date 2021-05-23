using Newtonsoft.Json;
using SearchFight.Models.Google;
using System.Configuration;

namespace SearchFight.SearchEngines
{
    public class GoogleSearch : ISearchEngine
    {
        private static string BaseUrl => ConfigurationManager.AppSettings["BASE_URL"];
        private static string ApiKey => ConfigurationManager.AppSettings["API_KEY"];
        private static string SearchEngineId => ConfigurationManager.AppSettings["SEARCH_ENGINE_ID"];

        public SearchEngine Engine { get; set; }

        public SearchEngineType Name { get; set; }

        public GoogleSearch()
        {
            Name = SearchEngineType.Google;
            Engine = new SearchEngine();
        }

        public long GetSearchResultCount(string searchInput)
        {
            string content = Engine.SearchResult(GetSearchRequest(searchInput));

            var googleResponse = JsonConvert.DeserializeObject<GoogleResponse>(content);
            var searchTotalResults = long.Parse(googleResponse.SearchInformation.TotalResults);

            Engine.SetMaxResults(searchTotalResults, searchInput);

            return searchTotalResults;
        }

        public static string GetSearchRequest(string searchInput)
        {
            return BaseUrl.Replace("{KEY}", ApiKey)
                          .Replace("{SEARCH_ENGINE_ID}", SearchEngineId)
                          .Replace("{QUERY}", searchInput);
        }
    }
}
