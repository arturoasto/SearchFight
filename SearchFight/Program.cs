using System;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] searchParams)
        {          
            Console.WriteLine("Search Fight ...");

            SearchFight.StartSearch(searchParams).GetAwaiter().GetResult();
            SearchFight.ReportService.ReportOutputs.ForEach(report => Console.WriteLine(report));

            Console.ReadLine();
        }
    }
}
