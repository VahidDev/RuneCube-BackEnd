namespace RuneCube.Utilities.GPT3
{
    public static class StoryPromptValidator
    {
        public static string ValidateStoryPrompts(string prompt)
        {
            if (!string.IsNullOrEmpty(prompt))
            {
                int lastIndex = prompt.Length - 1;
                if (prompt[lastIndex] != '.' || prompt[lastIndex] != '!')
                {
                    for (int i = lastIndex; i >= 0; i--)
                    {
                        if (prompt[i] == '.' || prompt[i] == '!') break;
                        prompt = prompt.Remove(i);
                    }
                }
            }
            return prompt;
        }
    }
}
