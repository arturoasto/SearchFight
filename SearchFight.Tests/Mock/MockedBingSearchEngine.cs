using SearchFight.Models.Bing;
using SearchFight.SearchEngines.Interfaces;
using System;
using System.Net.Http;
using System.Text.Json;

namespace SearchFight.Tests.Mock
{
    public class MockedBingSearchEngine : ISearchEngine
    {
        public HttpClient Client { get; set ; }
        public long MaxResult { get; set; }
        public string MaxWinner { get; set; }

        public void AddCustomHeader(string name, string value)
        {
            return;
        }

        public string SearchResult(string searchRequest)
        {
            return JsonSerializer.Serialize(new BingResponse()
            {
                WebPages = new WebPages()
                {
                    TotalEstimatedMatches = 100
                }
            });
        }

        public void SetMaxResults(long newResult, string searchInput)
        {
            return;
        }
    }
}
