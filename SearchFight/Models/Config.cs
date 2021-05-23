namespace SearchFight.Models.Config
{
    public class Config
    {
        public Google Google { get; set; }
        public Bing Bing { get; set; }
    }

    public class Google
    {
        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }
        public string SearchEngineId { get; set; }
    }

    public class Bing
    {
        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }
    }
}
