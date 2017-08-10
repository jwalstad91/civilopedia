using System.ComponentModel.DataAnnotations;

namespace civilopedia.Models
{
    public class Leader
    {
        public int Id { get; set; } // Primary Key

        public string Name { get; set; }

        public string Ability { get; set; }

        public string Agenda { get; set; }

        public int? CivId { get; set; } // Foreign Key
    }
}