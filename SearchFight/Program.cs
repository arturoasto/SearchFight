using System;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] searchParams)
        {          
            Console.WriteLine("Search Fight");
            Start(searchParams);
        }

        static void Start(string[] searchParams)
        {
            SearchFight.StartSearch(searchParams);
            SearchFight.ReportService.ReportOutputs.ForEach(report => Console.WriteLine(report));
        }
    }
}
