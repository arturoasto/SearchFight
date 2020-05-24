using Newtonsoft.Json;
using SearchFight.Models.Google;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight.SearchEngines
{
    public class GoogleSearch : Base, ISearchEngine
    {       
        private string BaseUrl => GetConfiguration("BASE_URL");
        private string ApiKey => GetConfiguration("API_KEY");
        private string SearchEngineId => GetConfiguration("SEARCH_ENGINE_ID");

        public GoogleSearch()
        {
            Client = new HttpClient();
        }

        public async Task<long> GetSearchResultCount(string searchInput)
        {
            string content = await SearchResult(Client, GetSearchRequest(searchInput));

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
