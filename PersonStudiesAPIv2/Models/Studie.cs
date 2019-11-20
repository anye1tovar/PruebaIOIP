using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonStudiesAPIv2.Models
{
    public class Studie
    {
        [Key]
        public int StudieId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(12)")] //BACHILLERATO
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")] //DD/MM/AAAA
        public string Datastart { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Dataend { get; set; }
        [Required]
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
