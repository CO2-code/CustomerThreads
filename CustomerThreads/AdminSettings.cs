using System.IO;
using Newtonsoft.Json;

namespace CustomerThreads
{
    public static class AdminSettings
    {
        private static string file = "admin.json";

        public static string PasswordHash { get; set; }

        public static void Load()
        {
            if (!File.Exists(file))
            {
                // default password = 1234
                PasswordHash = SecurityHelper.Hash("1234");
                Save();
                return;
            }

            var json = File.ReadAllText(file);
            PasswordHash = JsonConvert.DeserializeObject<string>(json);
        }

        public static void Save()
        {
            File.WriteAllText(file,
                JsonConvert.SerializeObject(PasswordHash, Formatting.Indented));
        }
    }
}