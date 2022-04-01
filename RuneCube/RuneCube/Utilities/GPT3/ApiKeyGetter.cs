using System;
using System.Threading.Tasks;

namespace RuneCube.Utilities.GPT3
{
    public static class ApiKeyGetter
    {
        public static async Task<string> GetApiKeyAsync()
        {
            return Environment.GetEnvironmentVariable("API_KEY");
        }
    }
}
