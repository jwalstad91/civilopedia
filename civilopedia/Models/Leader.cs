using System.ComponentModel.DataAnnotations;

namespace civilopedia.Models
{
    public class Leader
    {
        [Key]
        public int LeaderId { get; set; } // Primary Key

        [Required]
        public string LeaderName { get; set; }

        public string LeaderAbility { get; set; }

        public string LeaderAgenda { get; set; }

        public int CivId { get; set; } // Foreign Key

        public Civilization civilization { get; set; }
    }
}