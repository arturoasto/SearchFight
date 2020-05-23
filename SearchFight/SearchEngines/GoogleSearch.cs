using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.SearchEngines
{
    public class GoogleSearch : ISearchEngine
    {
        public string Name { get => this.GetType().Name.Replace("Search", ""); }
        public int MaxResult { get; set; }
        public string MaxWinner { get; set; }

        public int GetSearchResultCount(string searchInput)
        {
            return 0;
        }
    }
}
