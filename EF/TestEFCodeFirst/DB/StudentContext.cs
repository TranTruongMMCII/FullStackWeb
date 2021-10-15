using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestEFCodeFirst.Models;

namespace TestEFCodeFirst.DB
{
    public class StudentContext:DbContext
    {
        public StudentContext() : base("StudentContext")
        {
        
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}