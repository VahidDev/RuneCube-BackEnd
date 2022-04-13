using DomainModels.Models.Entities.Base;

namespace DomainModels.Models.Entities
{
   public class Setting:Entity
    {
        public int MaxResponseTime { get; set; }
        public int Count { get; set; }
        public int EachSideCount { get; set; }
        public int SidesTime { get; set; }
    }
}
