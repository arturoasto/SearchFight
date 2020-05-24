using System.Configuration;

namespace SearchFight.SearchEngines
{
    public abstract class Base
    {
        public string Name { get => this.GetType().Name.Replace("Search", ""); }
        public long MaxResult { get; set; }
        public string MaxWinner { get; set; }
        public string GetConfiguration(string key) => ConfigurationManager.AppSettings[key];

        public void SetMaxResults(long result, string searchInput)
        {
            if (result > MaxResult)
            {
                MaxResult = result;
                MaxWinner = searchInput;
            }
        }
    }
}