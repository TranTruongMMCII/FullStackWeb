using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.DB
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("StudentContext")
        {

        }

        public DbSet<Class> Classes;
        public DbSet<Student> Students;
    }
}