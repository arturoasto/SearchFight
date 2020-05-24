using System;
using System.Threading.Tasks;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] searchParams)
        {          
            Console.WriteLine("Search Fight");
            Start(searchParams).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static async Task Start(string[] searchParams)
        {
            await SearchFight.StartSearch(searchParams);
            SearchFight.ReportService.ReportOutputs.ForEach(report => Console.WriteLine(report));
        }
    }
}
