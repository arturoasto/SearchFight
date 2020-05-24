using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight.SearchEngines
{
    public class BingSearch : Base, ISearchEngine
    {
        private string BaseUrl => GetConfiguration("BING_BASE_URL");
        private string ApiKey => GetConfiguration("BING_API_KEY");

        private HttpClient Client { get; set; }

        public BingSearch()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ApiKey);
        }

        public async Task<long> GetSearchResultCount(string searchInput)
        {
            string searchRequest = BaseUrl.Replace("{KEY}", ApiKey)
                                          .Replace("{QUERY}", searchInput);            

            var response = await Client.GetAsync(searchRequest);

            var content = await response.Content.ReadAsStringAsync();

            var result = long.Parse(JObject.Parse(content)["webPages"]["totalEstimatedMatches"].ToString());
            SetMaxResults(result, searchInput);

            return result;
        }
    }
}
