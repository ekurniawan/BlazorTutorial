using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using LatihanBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LatihanBlazor.Pages
{
    public partial class EmployeePage
    {
        protected int SelectedEmployeesCount { get; set; } = 0;

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }

        public IEnumerable<Employee> Employees { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public bool ShowFooter { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        } 
    }
}