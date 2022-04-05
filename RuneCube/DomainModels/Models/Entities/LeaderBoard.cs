using DomainModels.Models.Entities.Base;

namespace DomainModels.Models.Entities
{
    public class LeaderBoard:Entity
    {
        public string Explorer { get; set; }
        public string Solver { get; set; }
        public string SpentTime { get; set; }
        public bool IsFinished { get; set; }

    }
}
