using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using LatihanBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LatihanBlazor.Pages
{
    public partial class EmployeePage
    {
        public IEnumerable<Employee> Employees { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        } 
    }
}