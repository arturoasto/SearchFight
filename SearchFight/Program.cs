using SearchFight.SearchEngines;
using System;
using System.Collections.Generic;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] searchParams)
        {
            Console.WriteLine("Search Fight ...");

            ReportService reportService = new(GetSearchEngines());
            reportService.AppendResultsByArgument(searchParams)
                         .AppendResultsBySearchEngine()
                         .AppendTotalWinner();

            reportService.ReportOutputs.ForEach(report => Console.WriteLine(report));

            Console.ReadLine();
        }

        static List<ISearchEngine> GetSearchEngines()
        {
            return new List<ISearchEngine>()
            {
                new GoogleSearch(),
                new BingSearch(),
            };
        }
    }
}
