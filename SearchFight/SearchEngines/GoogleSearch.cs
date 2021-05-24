using SearchFight.Models.Google;
using SearchFight.SearchEngines.Interfaces;
using System;
using System.Text.Json;

namespace SearchFight.SearchEngines
{
    public class GoogleSearch : ICustomSearchEngine
    {
        private static readonly string BaseUrl = ConfigService.Config.Google.ApiUrl;
        private static readonly string ApiKey = ConfigService.Config.Google.ApiKey;
        private static readonly string SearchEngineId = ConfigService.Config.Google.SearchEngineId;

        public ISearchEngine Engine { get; set; }
        public SearchEngineType Name { get; set; }

        public GoogleSearch(ISearchEngine searchEngine)
        {
            Name = SearchEngineType.Google;
            Engine = searchEngine;
        }

        public long GetSearchResultCount(string searchInput)
        {
            string content = Engine.SearchResult(GetSearchRequest(searchInput));

            var googleResponse = JsonSerializer.Deserialize<GoogleResponse>(content, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true });
            var searchTotalResults = long.Parse(googleResponse.SearchInformation.TotalResults);

            Engine.SetMaxResults(searchTotalResults, searchInput);

            return searchTotalResults;
        }

        public static string GetSearchRequest(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput)) throw new ArgumentNullException(searchInput);

            return BaseUrl.Replace("{KEY}", ApiKey)
                          .Replace("{SEARCH_ENGINE_ID}", SearchEngineId)
                          .Replace("{QUERY}", searchInput);
        }
    }
}
