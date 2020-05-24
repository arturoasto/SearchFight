using SearchFight.SearchEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public ReportService AppendResultsByArgument(string[] args)
        {
            if (args == null) throw new ArgumentException("You should provide words to start the search");

            var arguments = args.ToList();

            arguments.ForEach(argument =>
            {
                var lineResult = new StringBuilder($"{argument}:");

                SearchEngines.ForEach(searchEngine =>
                {
                    lineResult.Append($" {searchEngine.Name}: {searchEngine.GetSearchResultCount(argument).GetAwaiter().GetResult()}");
                });

                ReportOutputs.Add(lineResult.ToString());
            });

            return this;
        }

        public ReportService AppendResultsBySearchEngine()
        {
            SearchEngines.ForEach(searchEngine => ReportOutputs.Add($"{searchEngine.Name} winner: {searchEngine.MaxWinner}"));
            return this;
        }

        public ReportService AppendTotalWinner()
        {
            var maxResult = SearchEngines.Max(x => x.MaxResult);
            var totalWinner = SearchEngines.Where(x => x.MaxResult == maxResult).Select(x => x.MaxWinner).First();

            ReportOutputs.Add($"Total winner: {totalWinner}");
            return this;
        }
    }
}
