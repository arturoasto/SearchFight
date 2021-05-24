using Bogus;
using SearchFight.Models.Google;
using SearchFight.SearchEngines.Interfaces;
using System.Net.Http;
using System.Text.Json;

namespace SearchFight.Tests.Mock
{
    internal class MockedGoogleSearchEngine : ISearchEngine
    {
        public HttpClient Client { get; set; }
        public long MaxResult { get; set; }
        public string MaxWinner { get; set; }

        public void AddCustomHeader(string name, string value)
        {
            return;
        }

        public string SearchResult(string searchRequest)
        {
            return JsonSerializer.Serialize(new GoogleResponse()
            {
                SearchInformation = new SearchInformation()
                {
                    TotalResults = "100"
                }
            });
        }

        public void SetMaxResults(long newResult, string searchInput)
        {
            return;
        }
    }
}
