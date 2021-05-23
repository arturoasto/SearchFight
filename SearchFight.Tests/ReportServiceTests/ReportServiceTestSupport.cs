using SearchFight.SearchEngines;
using SearchFight.Tests.Mock;
using System;
using System.Collections.Generic;

namespace SearchFight.Tests.ReportServiceTests
{
    internal class ReportServiceTestSupport
    {
        internal static List<ISearchEngine> GetSearchEngines()
        {
            List<ISearchEngine> searchEngines = new();

            foreach (SearchEngineType searchEngine in Enum.GetValues(typeof(SearchEngineType)))
            {
                searchEngines.Add(new MockedSearchEngine()
                {
                    Name = searchEngine,
                    Engine = new SearchEngine()
                    {
                        MaxResult = long.MaxValue,
                        MaxWinner = "search fight"
                    }                    
                });
            }

            return searchEngines;
        }
    }
}