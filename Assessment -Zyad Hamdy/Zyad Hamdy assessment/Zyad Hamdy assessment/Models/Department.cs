using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyad_Hamdy_assessment.Models
{
    internal class Department
    {
        [Key]
        public int  D_id { get; set; }
        public string? Dname { get; set; }
    }
}
