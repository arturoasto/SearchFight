using System.Diagnostics.CodeAnalysis;

namespace SearchFight.Models.Config
{
    [ExcludeFromCodeCoverage]
    public class Config
    {
        public Google Google { get; set; }
        public Bing Bing { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class Google
    {
        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }
        public string SearchEngineId { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class Bing
    {
        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }
    }
}
