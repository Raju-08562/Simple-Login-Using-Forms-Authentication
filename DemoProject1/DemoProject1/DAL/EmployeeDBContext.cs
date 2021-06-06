using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DemoProject1.Login;
using DemoProject1.Models;



namespace DAL
{
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<MemberLogin> members { get; set; }
    }
}