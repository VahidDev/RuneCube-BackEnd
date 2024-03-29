﻿namespace RuneCube.Utilities.GPT3
{
    public static class StoryPromptValidator
    {
        public static string ValidateStoryPrompts(string prompt)
        {
            prompt = prompt.Trim();
            if (!string.IsNullOrEmpty(prompt))
            {
                int lastIndex = prompt.Length - 1;
                if (prompt[lastIndex] != '.' && prompt[lastIndex] != '!')
                {
                    for (int i = lastIndex; i >= 0; i--)
                    {
                        if (prompt[i] == '.' || prompt[i] == '!') break;
                        prompt = prompt.Remove(i, 1);
                    }
                }
            }
            if (!string.IsNullOrEmpty(prompt))
            {
                if (prompt[0] == '.' || prompt[0] == '!' || prompt[0] == ',')
                {
                    for (int i = 0; i < prompt.Length; i++)
                    {
                        if (prompt[i] != '.' && prompt[i] != '!' && prompt[i] != ',') break;
                        prompt = prompt.Remove(i, 1);
                        i--;
                    }
                }
            }
            return prompt;
        }
    }
}
