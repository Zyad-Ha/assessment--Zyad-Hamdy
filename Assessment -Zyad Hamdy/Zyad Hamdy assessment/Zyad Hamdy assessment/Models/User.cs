using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyad_Hamdy_assessment.Models
{
    internal class User
    {
        [Key]
        public int U_id { get; set; }
        [ForeignKey("D_id")]
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }
    
        public string? Uname { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? address { get; set; }
        public string? jop_title { get; set; }
        public string? salary { get; set; }
        public string? role { get; set; }
        
    }
}
