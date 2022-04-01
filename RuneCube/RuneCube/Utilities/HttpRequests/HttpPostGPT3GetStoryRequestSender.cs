using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RuneCube.Constants.GPT3Contants;
using RuneCube.Utilities.GPT3;

namespace RuneCube.Utilities.HttpRequests
{
    public static class HttpPostGPT3GetStoryRequestSender
    {
        public static async Task<string> GetStoryPromptAsync(string prompt)
        {
            using HttpClient client = new();
            string url = Gpt3EndpointConstants.StoryGetterEndpoint;
            string key = Environment.GetEnvironmentVariable("API_KEY");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + key);
            StringContent data = new(Gpt3JsonGenerator.GetGpt3Json(prompt), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, data);
            string result = await response.Content.ReadAsStringAsync();
            JObject root = JObject.Parse(result);
            string story = "";
            if (root["choices"] != null)
            {
                story = root["choices"][0]["text"].ToString().Trim();
            }
            return story;
        }
    }
}
