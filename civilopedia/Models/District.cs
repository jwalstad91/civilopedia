using System.ComponentModel.DataAnnotations;

namespace civilopedia.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public string Name { get; set; }

        public int ProductionCost { get; set; }

        public int MaintenanceCost { get; set; }

        public bool IsUnique { get; set; }

        public int? CivId { get; set; } // Foreign Key
    }
}