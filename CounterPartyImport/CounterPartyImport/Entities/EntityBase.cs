using System.ComponentModel.DataAnnotations;

namespace CounterPartyImport.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
