﻿using Newtonsoft.Json;
using SearchFight.Models.Bing;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight.SearchEngines
{
    public class BingSearch : SearchEngine, ISearchEngine
    {
        private static string BaseUrl => GetConfiguration("BING_BASE_URL");
        private static string ApiKey => GetConfiguration("BING_API_KEY");

        public BingSearch()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ApiKey);
        }

        public long GetSearchResultCount(string searchInput)
        {
            string content = SearchResult(Client, GetSearchRequest(searchInput));

            var bingResponse = JsonConvert.DeserializeObject<BingResponse>(content);
            var searchTotalResults = long.Parse(bingResponse.WebPages.TotalEstimatedMatches);

            SetMaxResults(searchTotalResults, searchInput);

            return searchTotalResults;
        }

        protected override string GetSearchRequest(string searchInput)
        {
            return BaseUrl.Replace("{KEY}", ApiKey)
                          .Replace("{QUERY}", searchInput);
        }
    }
}
