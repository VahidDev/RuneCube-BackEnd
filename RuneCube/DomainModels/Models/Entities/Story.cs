using DomainModels.Models.Entities.Base;

namespace DomainModels.Models.Entities
{
    public class Story:Entity
    {
        public string StoryStartPrompt { get; set; }
        public string StoryEndPrompt { get; set; }
    }
}
