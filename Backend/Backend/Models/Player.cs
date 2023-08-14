using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Player
    {
        [Key]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public int Balance { get; set; }
    }
}