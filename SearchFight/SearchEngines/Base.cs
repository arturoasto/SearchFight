using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchFight.SearchEngines
{
    public abstract class Base
    {
        #region Public Area

        public string Name { get => this.GetType().Name.Replace("Search", ""); }
        public long MaxResult { get; set; }
        public string MaxWinner { get; set; }

        #endregion

        #region Protected Area

        protected HttpClient Client { get; set; }
        protected string GetConfiguration(string key) => ConfigurationManager.AppSettings[key];
        protected abstract string GetSearchRequest(string searchInput);

        protected static async Task<string> SearchResult(HttpClient client, string searchRequest)
        {
            var response = await client.GetAsync(searchRequest);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        protected void SetMaxResults(long result, string searchInput)
        {
            if (result > MaxResult)
            {
                MaxResult = result;
                MaxWinner = searchInput;
            }
        }

        #endregion
    }
}