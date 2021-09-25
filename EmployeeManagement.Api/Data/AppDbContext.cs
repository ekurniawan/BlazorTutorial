using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed tabel department
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId=1,DepartmentName="IT" }
            );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId=2,DepartmentName="HR" }
            );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId=3,DepartmentName="Payroll" }
            );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId=4,DepartmentName="Admin" }
            );

            //seed employee
            modelBuilder.Entity<Employee>().HasData(new Employee{
                EmployeeId = 1,
                FirstName = "Erick",
                LastName = "Kurniawan",
                Email = "erick@gmail.com",
                DateOfBirth = new DateTime(1990,10,5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/erick.png"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee{
                EmployeeId = 2,
                FirstName = "Argo",
                LastName = "Bromo",
                Email = "argo@gmail.com",
                DateOfBirth = new DateTime(1992,10,5),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/argo.png"
            });
        }
    }


}