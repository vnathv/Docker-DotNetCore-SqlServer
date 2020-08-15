using Microsoft.EntityFrameworkCore;
using System;

namespace Employee.DataAccessLayer.DBContexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data

            
            modelBuilder.Entity<Employee>().HasKey(e => new { e.Id });

            Console.WriteLine("Seeding data to Employee table");

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    FirstName = "David",
                    LastName = "Mike",
                    Age = 50
                },
               new Employee
               {
                   FirstName = "Steve",
                   LastName = "Warner",
                   Age = 50
               }
               );



            base.OnModelCreating(modelBuilder);
        }
    }
}
