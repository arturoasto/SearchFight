using System.Text.Json;
using System.IO;
using SearchFight.Models.Config;

namespace SearchFight
{
    public class ConfigService
    {
        public static readonly Config Config = GetConfiguration();

        public static Config GetConfiguration()
        {
            string jsonFile = File.ReadAllText("AppConfig.json");
            return JsonSerializer.Deserialize<Config>(jsonFile);
        }
    }
}
