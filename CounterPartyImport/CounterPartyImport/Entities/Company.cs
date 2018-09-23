using System.ComponentModel.DataAnnotations;

namespace CounterPartyImport.Entities
{
    public class Company : EntityBase
    {
        [Required]
        public string ExternalId { get; set; }
        [Required]
        public string TradingName { get; set; }
        [Required]
        public string LegalName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool IsForwarder { get; set; }
        public bool IsActive { get; set; }
    }
}
