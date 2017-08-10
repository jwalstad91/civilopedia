using System.ComponentModel.DataAnnotations;

namespace civilopedia.Models
{
    public class Civilization
    {
        public int Id { get; set; } // Primary Key

        public string Name { get; set; }
    }
}