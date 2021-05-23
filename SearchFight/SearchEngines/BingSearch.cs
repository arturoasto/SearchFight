using SearchFight.Models.Bing;
using System.Text.Json;

namespace SearchFight.SearchEngines
{
    public class BingSearch : ISearchEngine
    {
        private const string BaseUrl = "https://api.cognitive.microsoft.com/bing/v7.0/search?q={QUERY}";
        private const string ApiKey = "";

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
            var bingResponse = JsonSerializer.Deserialize<BingResponse>(content);
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
