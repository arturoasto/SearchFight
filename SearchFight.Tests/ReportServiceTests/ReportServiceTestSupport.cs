using SearchFight.SearchEngines;
using SearchFight.Tests.Mock;
using System.Collections.Generic;

namespace SearchFight.Tests.ReportServiceTests
{
    internal class ReportServiceTestSupport
    {
        internal List<ISearchEngine> GetSearchEngines()
        {
            return new List<ISearchEngine>()
            {
                new MockedSearchEngine(){}
            };
        }
    }
}