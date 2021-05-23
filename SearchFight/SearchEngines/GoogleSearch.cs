using Newtonsoft.Json;
using SearchFight.Models.Google;
using System.Net.Http;

namespace SearchFight.SearchEngines
{
    public class GoogleSearch : SearchEngine, ISearchEngine
    {       
        private static string BaseUrl => GetConfiguration("BASE_URL");
        private static string ApiKey => GetConfiguration("API_KEY");
        private static string SearchEngineId => GetConfiguration("SEARCH_ENGINE_ID");

        public GoogleSearch()
        {
            Client = new HttpClient();
        }

        public long GetSearchResultCount(string searchInput)
        {
            string content = SearchResult(Client, GetSearchRequest(searchInput));

            var googleResponse = JsonConvert.DeserializeObject<GoogleResponse>(content);
            var searchTotalResults = long.Parse(googleResponse.SearchInformation.TotalResults);

            SetMaxResults(searchTotalResults, searchInput);

            return searchTotalResults;
        }

        protected override string GetSearchRequest(string searchInput)
        {
            return BaseUrl.Replace("{KEY}", ApiKey)
                          .Replace("{SEARCH_ENGINE_ID}", SearchEngineId)
                          .Replace("{QUERY}", searchInput);
        }
    }
}
