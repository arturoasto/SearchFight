using Newtonsoft.Json;
using SearchFight.Models.Google;
using System.Configuration;

namespace SearchFight.SearchEngines
{
    public class GoogleSearch : ISearchEngine
    {       
        private static string BaseUrl => GetConfiguration("BASE_URL");
        private static string ApiKey => GetConfiguration("API_KEY");
        private static string SearchEngineId => GetConfiguration("SEARCH_ENGINE_ID");

        public SearchEngine Engine { get; set; }

        public SearchEngineType Name { get; set; }

        public long MaxResult { get; set; }
        public string MaxWinner { get; set; }

        public GoogleSearch()
        {
            Name = SearchEngineType.Google;
            Engine = new SearchEngine();
        }

        public static string GetConfiguration(string key) => ConfigurationManager.AppSettings[key];

        public long GetSearchResultCount(string searchInput)
        {
            string content = Engine.SearchResult(GetSearchRequest(searchInput));

            var googleResponse = JsonConvert.DeserializeObject<GoogleResponse>(content);
            var searchTotalResults = long.Parse(googleResponse.SearchInformation.TotalResults);

            (MaxResult, MaxWinner) = SearchEngine.SetMaxResults(searchTotalResults, MaxResult, MaxWinner, searchInput);

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
