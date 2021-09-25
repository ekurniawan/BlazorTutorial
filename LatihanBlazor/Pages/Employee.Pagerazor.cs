using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace LatihanBlazor.Pages
{
    public partial class EmployeePage
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadEmployees);
        }

        private void LoadEmployees(){
            System.Threading.Thread.Sleep(2000);

            Employee e1 = new Employee{
                EmployeeId=1,
                FirstName="Erick",
                LastName="Kurniawan",
                Email="erick@actual-training.com",
                DateOfBirth = new DateTime(1999,10,5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/erick.png"
            };

            Employee e2 = new Employee{
                EmployeeId=2,
                FirstName="Budi",
                LastName="Sutejo",
                Email="budi@actual-training.com",
                DateOfBirth = new DateTime(1967,10,5),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/budi.jpg"
            };

            Employee e3 = new Employee{
                EmployeeId=3,
                FirstName="Argo",
                LastName="Bromo",
                Email="argo@actual-training.com",
                DateOfBirth = new DateTime(2000,5,5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/argo.png"
            };

            Employee e4 = new Employee{
                EmployeeId=4,
                FirstName="Cloud",
                LastName="Strife",
                Email="cloud@actual-training.com",
                DateOfBirth = new DateTime(2000,6,5),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/cloud.png"
            };

            Employees = new List<Employee>{e1,e2,e3,e4};
        }
    }
}