﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace civilopedia.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public string Name { get; set; }

        public bool IsUnique { get; set; }

        public int? CivId { get; set; } // Foreign Key

        public int MeleeStrength { get; set; }

        public int RangedStrength { get; set; }

        public int AttackRange { get; set; }

        public int MaintenanceCost { get; set; }

        public int ProductionCost { get; set; }

        public string Ability { get; set; }
    }
}