using Newtonsoft.Json;
using RuneCube.Constants.GPT3Contants;

namespace RuneCube.Utilities.GPT3
{
    public static class Gpt3JsonGenerator
    {
        public static string GetGpt3Json(string prompt)
        {
            return JsonConvert.SerializeObject(new
            {
                prompt,
                temperature = Gpt3ConfigConstants.Temperature,
                max_tokens = Gpt3ConfigConstants.MaxTokens,
                top_p = Gpt3ConfigConstants.TopP,
                frequency_penalty = Gpt3ConfigConstants.FrequencyPenalty,
                presence_penalty = Gpt3ConfigConstants.PresencePenalty
            });
        }
    }
}
