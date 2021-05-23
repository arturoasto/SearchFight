using SearchFight.Models.Google;
using System.Text.Json;

namespace SearchFight.SearchEngines
{
    public class GoogleSearch : ISearchEngine
    {
        private const string BaseUrl = "https://www.googleapis.com/customsearch/v1?key={KEY}&amp;cx={SEARCH_ENGINE_ID}&amp;q={QUERY}";
        private const string ApiKey = "";
        private const string SearchEngineId = "";

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

            var googleResponse = JsonSerializer.Deserialize<GoogleResponse>(content);
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
