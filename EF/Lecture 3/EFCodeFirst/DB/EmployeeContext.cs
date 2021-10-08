using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirst.Model;

namespace EFCodeFirst.DB
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext() : base("EmployeeConnectionString") { }

        public DbSet<Employee> Employees { get; set; }
    }
}
