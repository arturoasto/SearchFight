using SearchFight.SearchEngines;
using SearchFight.SearchEngines.Interfaces;
using SearchFight.Tests.Mock;
using System;
using System.Collections.Generic;

namespace SearchFight.Tests.ReportServiceTests
{
    internal class ReportServiceTestSupport
    {
        internal static List<ICustomSearchEngine> GetSearchEngines(ISearchEngine searchEngine)
        {
            List<ICustomSearchEngine> searchEngines = new();

            foreach (SearchEngineType type in Enum.GetValues(typeof(SearchEngineType)))
            {
                searchEngines.Add(new MockedCustomSearchEngine(searchEngine)
                {
                    Name = type
                });
            }

            return searchEngines;
        }

        internal static ISearchEngine GetCustomSearchEngineDefault()
        {          
            return new SearchEngine()
            {
                MaxResult = long.MaxValue,
                MaxWinner = "search fight"
            };
        }

        internal static ISearchEngine GetCustomSearchEngineEmpty()
        {
            return new SearchEngine();
        }
    }
}