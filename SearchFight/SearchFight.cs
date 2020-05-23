using SearchFight.SearchEngines;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight
{
    public static class SearchFight
    {
        public static ReportService ReportService;

        static SearchFight()
        {
            ReportService = new ReportService(GetSearchEngines());
        }

        private static List<ISearchEngine> GetSearchEngines()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName.StartsWith("SearchFight"))
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(ISearchEngine).ToString()) != null)
                .Select(type => Activator.CreateInstance(type) as ISearchEngine)
                .ToList();
        }

        public static void StartSearch(string[] args)
        {
            ReportService.AppendResultsByArgument(args)
                         .AppendResultsBySearchEngine()
                         .AppendTotalWinner();
        }
    }
}
