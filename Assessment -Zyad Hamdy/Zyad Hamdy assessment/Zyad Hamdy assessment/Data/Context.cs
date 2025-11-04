using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zyad_Hamdy_assessment.Models;

namespace Zyad_Hamdy_assessment.Data
{
    internal class Context: DbContext
    {
        public Context() { }
        public Context(DbContextOptions options):base (options) { }
        public DbSet<User> User { get; set; }
        public DbSet<LeaveRequest> LeaveRequest  { get; set; }
        public DbSet<Department> Department  { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=COM179-LAB3\\SQLEXPRESS;Initial Catalog=asessmentMS;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
