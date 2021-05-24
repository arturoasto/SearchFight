using SearchFight.Models.Bing;
using SearchFight.SearchEngines.Interfaces;
using System;
using System.Net.Http;
using System.Text.Json;

namespace SearchFight.SearchEngines
{
    public class BingSearch : ICustomSearchEngine
    {
        private static readonly string BaseUrl = ConfigService.Config.Bing.ApiUrl;
        private static readonly string ApiKey = ConfigService.Config.Bing.ApiKey;

        public ISearchEngine Engine { get; set; }
        public SearchEngineType Name { get; set; }

        public BingSearch(ISearchEngine searchEngine)
        {
            Name = SearchEngineType.Bing;
            Engine = searchEngine;
            searchEngine.AddCustomHeader("Ocp-Apim-Subscription-Key", ApiKey);
        }

        public long GetSearchResultCount(string searchInput)
        {
            string content = Engine.SearchResult(GetSearchRequest(searchInput));
            var bingResponse = JsonSerializer.Deserialize<BingResponse>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            var searchTotalResults = bingResponse.WebPages.TotalEstimatedMatches;

            Engine.SetMaxResults(searchTotalResults, searchInput);

            return searchTotalResults;
        }

        public static string GetSearchRequest(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput)) throw new ArgumentNullException(searchInput);

            return BaseUrl.Replace("{KEY}", ApiKey)
                          .Replace("{QUERY}", searchInput);
        }
    }
}
