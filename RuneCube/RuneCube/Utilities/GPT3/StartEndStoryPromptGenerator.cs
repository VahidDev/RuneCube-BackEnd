using System;
using System.Threading.Tasks;
using AutoMapper;
using DomainModels.Dtos.StoryDtos;
using DomainModels.Models.Entities;
using Repository.Services.Abstarction;

namespace RuneCube.Utilities.GPT3
{
    public static class StartEndStoryPromptGenerator
    { 
        public static async Task<StoryPromptDto> GenerateStartEndStoryPromptAsync(
            IUnitOfWork unitOfWork,IMapper mapper)
        {
            // Closing api usage (there is lots of stories in the database)
            //StoryPromptDto dto = await RandomStoryPromptGenerator.GetRandomStoryPromptAsync();
            StoryPromptDto dto = new();
            //Check if dto is empty. If yes then take from database if not then add to db 
            // and use the delivered stories
            if (dto.StoryStartPrompt.Length > 0 && dto.StoryEndPrompt.Length > 0)
            {
                // disabling this so that we don't fill the database
                // (cuz of free subscription of heroku)

                //await unitOfWork.Stories.AddAsync(mapper.Map<Story>(dto));
                //await unitOfWork.CompleteAsync();
            }
            else
            {
                Random random = new();
                int randomNumber = random.Next(0, await unitOfWork.Stories.GetCountAsync()+1);
                Story story = await unitOfWork.Stories.GetSkippedAsync(randomNumber, 1);
                dto = mapper.Map<StoryPromptDto>(story);
            }

            dto.StoryStartPrompt = StoryPromptValidator.ValidateStoryPrompts(dto.StoryStartPrompt);
            dto.StoryEndPrompt = StoryPromptValidator.ValidateStoryPrompts(dto.StoryEndPrompt);
            // Capitalize the first letters cuz of openAI malfunction
            dto.StoryStartPrompt = char.ToUpper(dto.StoryStartPrompt[0]) + dto.StoryStartPrompt.Substring(1);
            dto.StoryEndPrompt = char.ToUpper(dto.StoryEndPrompt[0]) + dto.StoryEndPrompt.Substring(1);
            return dto;
        }
    }
}
