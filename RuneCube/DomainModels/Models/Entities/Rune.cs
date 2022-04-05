using System.ComponentModel.DataAnnotations.Schema;
using DomainModels.Models.Entities.Base;
namespace DomainModels.Models.Entities
{
    public class Rune:Entity
    {
        public string Value { get; set; }
        [NotMapped]
        public string Color { get; set; }
    }
}
