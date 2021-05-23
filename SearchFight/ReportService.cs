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
        public List<ICustomSearchEngine> SearchEngines { get; set; }

        public ReportService(List<ICustomSearchEngine> searchEngines)
        {
            SearchEngines = searchEngines;
            ReportOutputs = new List<string>();
        }

        public void LoadReport(string[] args)
        {
            AppendResultsByArgument(args);
            AppendResultsBySearchEngine();
            AppendTotalWinner();
        }

        public void ShowReport()
        {
            ReportOutputs.ForEach(report => Console.WriteLine(report));
        }

        public void AppendResultsByArgument(string[] args)
        {
            if (args.Length == 0) throw new ArgumentException("You should provide words to start the search");

            foreach (var arg in args)
            {                
                ReportOutputs.Add(GetReportLine(arg));
            }
        }

        public string GetReportLine(string arg)
        {
            var reportLine = $"{arg}:";
            SearchEngines.ForEach(x => reportLine += $" {x.Name}: {x.GetSearchResultCount(arg)}");
            return reportLine;
        }

        public void AppendResultsBySearchEngine()
        {
            SearchEngines.ForEach(searchEngine => ReportOutputs.Add($"{searchEngine.Name} winner: {searchEngine.Engine.MaxWinner}"));
        }

        public void AppendTotalWinner()
        {
            var totalWinner = SearchEngines.First(x => x.Engine.MaxResult == SearchEngines.Max(x => x.Engine.MaxResult)).Engine.MaxWinner;

            ReportOutputs.Add($"Total winner: {totalWinner}");
        }
    }
}
