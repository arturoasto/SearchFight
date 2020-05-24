using System.Threading.Tasks;

namespace SearchFight.SearchEngines
{
    public interface ISearchEngine
    {
        string Name { get; }
        long MaxResult { get; set; }
        string MaxWinner { get; set; }
        Task<long> GetSearchResultCount(string searchInput);
    }
}
