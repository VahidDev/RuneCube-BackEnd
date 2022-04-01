using System;
using System.Threading.Tasks;
using DomainModels.Dtos.StoryDtos;
using RuneCube.Constants.GPT3Contants;
using RuneCube.Utilities.HttpRequests;

namespace RuneCube.Utilities.GPT3
{
    public static class RandomStoryPromptGenerator
    {
        public static async Task<StoryPromptDto> GetRandomStoryPromptAsync()
        {
            StoryPromptDto dto = new();
            Random rnd = new();
            int number = rnd.Next(1, 6);
            switch (number)
            {
                case 1:
                    dto.StoryStartPrompt = await HttpPostGPT3GetStoryRequestSender.
                        GetStoryPromptAsync(Gpt3StoryPromptConstants.MazeStartPrompt);
                    dto.StoryEndPrompt = await HttpPostGPT3GetStoryRequestSender.
                        GetStoryPromptAsync(Gpt3StoryPromptConstants.MazeEndPrompt);
                    break;
                case 2:
                    dto.StoryStartPrompt = await HttpPostGPT3GetStoryRequestSender.
                        GetStoryPromptAsync(Gpt3StoryPromptConstants.ForestStartPrompt);
                    dto.StoryEndPrompt = await HttpPostGPT3GetStoryRequestSender.
                        GetStoryPromptAsync(Gpt3StoryPromptConstants.ForestEndPrompt);
                    break;
                case 3:
                    dto.StoryStartPrompt = await HttpPostGPT3GetStoryRequestSender.
                       GetStoryPromptAsync(Gpt3StoryPromptConstants.MarsStartPrompt);
                    dto.StoryEndPrompt = await HttpPostGPT3GetStoryRequestSender.
                        GetStoryPromptAsync(Gpt3StoryPromptConstants.MarsEndPrompt);
                    break;
                case 4:
                    dto.StoryStartPrompt = await HttpPostGPT3GetStoryRequestSender.
                       GetStoryPromptAsync(Gpt3StoryPromptConstants.ScaryHouseStartPrompt);
                    dto.StoryEndPrompt = await HttpPostGPT3GetStoryRequestSender.
                        GetStoryPromptAsync(Gpt3StoryPromptConstants.ScaryHouseEndPrompt);
                    break;
                case 5:
                    dto.StoryStartPrompt = await HttpPostGPT3GetStoryRequestSender.
                      GetStoryPromptAsync(Gpt3StoryPromptConstants.SpaceStartPrompt);
                    dto.StoryEndPrompt = await HttpPostGPT3GetStoryRequestSender.
                        GetStoryPromptAsync(Gpt3StoryPromptConstants.SpaceEndPrompt);
                    break;
                default:
                    break;
            }
            return dto;
        }
    }
}
