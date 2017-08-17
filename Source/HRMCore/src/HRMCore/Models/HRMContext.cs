using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMCore.Models
{
    public class HRMContext : DbContext
    {
        public HRMContext(DbContextOptions<HRMContext> options)
       : base(options)
        { }

        public DbSet<Dept> Depts { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
