using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight.SearchEngines
{
    public class GoogleSearch : Base, ISearchEngine
    {
        private string BaseUrl => GetConfiguration("BASE_URL");
        private string ApiKey => GetConfiguration("API_KEY");
        private string SearchEngineId => GetConfiguration("SEARCH_ENGINE_ID");

        public async Task<long> GetSearchResultCount(string searchInput)
        {
            string searchRequest = BaseUrl.Replace("{KEY}", ApiKey)
                                          .Replace("{SEARCH_ENGINE_ID}", SearchEngineId)
                                          .Replace("{QUERY}", searchInput);

            var response = await new HttpClient().GetAsync(searchRequest);
            var content =  await response.Content.ReadAsStringAsync();

            var result = long.Parse(JObject.Parse(content)["searchInformation"]["totalResults"].ToString());
            SetMaxResults(result, searchInput);

            return result;
        }
    }
}
