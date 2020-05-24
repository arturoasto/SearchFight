using SearchFight.SearchEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight
{
    public class ReportService
    {
        public List<string> ReportOutputs { get; set; }
        public List<ISearchEngine> SearchEngines { get; set; }

        public ReportService(List<ISearchEngine> searchEngines)
        {
            SearchEngines = searchEngines;
            ReportOutputs = new List<string>();
        }

        public async Task<ReportService> AppendResultsByArgument(string[] args)
        {
            if (args.Count() == 0) throw new ArgumentException("You should provide words to start the search");

            foreach (var arg in args)
            {
                var lineResult = new StringBuilder($"{arg}:");

                foreach (var searchEngine in SearchEngines)
                {
                    lineResult.Append($" {searchEngine.Name}:");
                    lineResult.Append($" {await searchEngine.GetSearchResultCount(arg)}");
                }

                ReportOutputs.Add(lineResult.ToString());
            }

            return this;
        }

        public ReportService AppendResultsBySearchEngine()
        {
            SearchEngines.ForEach(searchEngine => ReportOutputs.Add($"{searchEngine.Name} winner: {searchEngine.MaxWinner}"));
            return this;
        }

        public void AppendTotalWinner()
        {
            var maxResult = SearchEngines.Max(x => x.MaxResult);
            var totalWinner = SearchEngines.Where(x => x.MaxResult == maxResult).Select(x => x.MaxWinner).First();

            ReportOutputs.Add($"Total winner: {totalWinner}");
        }
    }
}
