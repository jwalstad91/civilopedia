using System.ComponentModel.DataAnnotations;

namespace civilopedia.Models
{
    public class Building
    {
        [Required]
        public int BuildingId { get; set; } // Primary Key

        [Required]
        public string BuildingName { get; set; }

        public int ProductionCost { get; set; }

        public int MaintenanceCost { get; set; }

        public bool IsUnique { get; set; }

        public int CivId { get; set; } // Foreign Key
    }
}