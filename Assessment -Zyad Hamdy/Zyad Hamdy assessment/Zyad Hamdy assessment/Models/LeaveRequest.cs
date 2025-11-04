using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyad_Hamdy_assessment.Models
{
    internal class LeaveRequest
    {
        [Key]
        public int R_id { get; set; }
        [ForeignKey("U_id")]
        public int UserID { get; set; }
        public User? User { get; set; }
        
        public DateOnly startDate  { get; set; }
        public DateOnly endDate  { get; set; }
        public string? LeaveType { get; set; }
        public string? status { get; set; }

    }
}
