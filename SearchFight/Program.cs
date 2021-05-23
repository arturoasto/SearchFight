using System;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] searchParams)
        {          
            Console.WriteLine("Search Fight ...");

            SearchFight searchFight = new();
            searchFight.StartSearch(searchParams);
            searchFight.ReportService.ReportOutputs.ForEach(report => Console.WriteLine(report));

            Console.ReadLine();
        }
    }
}
