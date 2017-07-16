using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace civilopedia.Models
{
    public class Leader
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Foreign Key
        public int CivilizationId { get; set; }
        // Navigation property
        public Civilization civilization { get; set; }
    }
}