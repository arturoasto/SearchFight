using SearchFight.SearchEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight
{
    public static class SearchFight
    {
        public static ReportService ReportService;

        static SearchFight()
        {
            ReportService = new ReportService(GetSearchEngines());
        }

        public static async Task StartSearch(string[] args)
        {
            await ReportService.AppendResultsByArgument(args);
            ReportService.AppendResultsBySearchEngine()
                         .AppendTotalWinner();
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
    }
}
