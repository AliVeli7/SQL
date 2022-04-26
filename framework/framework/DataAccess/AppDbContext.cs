using framework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace framework.DataAccess
{
   public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BBA44T6;Database=Holding;Integrated Security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
