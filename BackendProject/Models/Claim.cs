using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class Claim
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ClaimDate { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]
        public string ClaimNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Customer { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string CustomerRequisites { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string ListWorks { get; set; }
    }
}
