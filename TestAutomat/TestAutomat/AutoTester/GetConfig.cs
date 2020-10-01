using System.IO;

namespace TestAutomat.AutoTester
{
    public class GetConfig
    {
        public ConfigTests ConfigTests { get; set; }
        public ConfigDi ConfigDi { get; set; }
        public ConfigDa ConfigDa { get; set; }
        public ConfigAi ConfigAi { get; set; }
        public ConfigAa ConfigAa { get; set; }


        public GetConfig(DirectoryInfo aktuellesProjekt)
        {
            SetTestsConfig(aktuellesProjekt.FullName + "/test.json");
            SetDiConfig(aktuellesProjekt.FullName + "/DI.Json");
            SetDaConfig(aktuellesProjekt.FullName + "/DA.Json");
            SetAiConfig(aktuellesProjekt.FullName + "/AI.Json");
            SetAaConfig(aktuellesProjekt.FullName + "/AA.Json");
        }

        public void SetTestsConfig(string pfad) => ConfigTests = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigTests>(File.ReadAllText(pfad));
        public void SetDiConfig(string pfad) => ConfigDi = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigDi>(File.ReadAllText(pfad));
        internal void SetDaConfig(string pfad) => ConfigDa = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigDa>(File.ReadAllText(pfad));
        internal void SetAiConfig(string pfad) => ConfigAi = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigAi>(File.ReadAllText(pfad));
        public void SetAaConfig(string pfad) => ConfigAa = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfigAa>(File.ReadAllText(pfad));
    }
}