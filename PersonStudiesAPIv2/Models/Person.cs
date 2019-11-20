using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonStudiesAPIv2.Models
{ 
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Lastname { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Phone { get; set; }

    }
}