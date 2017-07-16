using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace civilopedia.Models
{
    public class Civilization
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // Foreign Keys
        public List<int> LeaderIds { get; set; }
    }
}