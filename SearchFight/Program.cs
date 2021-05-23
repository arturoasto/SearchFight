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
            reportService.LoadReport(searchParams);
            reportService.ShowReport();

            Console.ReadLine();
        }

        static List<ICustomSearchEngine> GetSearchEngines()
        {
            return new List<ICustomSearchEngine>()
            {
                new GoogleSearch(new SearchEngine()),
                new BingSearch(new SearchEngine()),
            };
        }
    }
}
