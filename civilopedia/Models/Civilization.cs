using System.ComponentModel.DataAnnotations;

namespace civilopedia.Models
{
    public class Civilization
    {
        [Required]
        public int CivId { get; set; } // Primary Key

        [Required]
        public string CivName { get; set; }
    }
}