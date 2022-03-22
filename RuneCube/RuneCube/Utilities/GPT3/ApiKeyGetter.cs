using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RuneCube.Utilities.GPT3
{
    public static class ApiKeyGetter
    {
        public static async Task<string> GetApiKeyAsync()
        {
            //StreamReader stream = File.OpenText
            //    ("C:\\Users\\User\\OneDrive\\Рабочий стол\\Rune Cube\\Secret.txt");
            //string str = await stream.ReadToEndAsync();
            //JObject json = JObject.Parse(str);
            return Environment.GetEnvironmentVariable("API_KEY");
        }
    }
}
