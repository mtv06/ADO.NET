using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class TaskForGrid
    {
        public int Id { get; set; }
        public DateTime TaskDate { get; set; }
        public string TaskNumber { get; set; }
        public int ClaimId { get; set; }
        public int BrigadeId { get; set; }
        public string TaskStaging { get; set; }
        public bool BrigadeConfirmation { get; set; }
        public string BrigadeNote { get; set; }
        public string BrigadeMark { get; set; }
        public string claimNumber { get; set; }
        public string customer { get; set; }
        public string brigadeNumber { get; set; }
        public string brigadeName { get; set; }
    }
}
