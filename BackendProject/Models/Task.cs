using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class Task
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime TaskDate { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]
        public string TaskNumber { get; set; }
        [Required]
        public int? ClaimId { get; set; }
        [ForeignKey("ClaimId")]
        public Claim Claim { get; set; }
        [Required]
        public int? BrigadeId { get; set; }
        [ForeignKey("BrigadeId")]
        public Brigade Brigade { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string TaskStaging { get; set; }
        [Column(TypeName = "bit")]
        [DefaultValue(0)]
        public bool BrigadeConfirmation { get; set; }
        [Column(TypeName = "text")]
        public string BrigadeNote { get; set; }
        [Column(TypeName = "text")]
        public string BrigadeMark { get; set; }
    }
}
