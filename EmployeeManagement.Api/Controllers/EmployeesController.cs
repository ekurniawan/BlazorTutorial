using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class EmployeesController : ControllerBase {
        private IEmployeeRepository _employeeRepository;
        public EmployeesController (IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(){
            return Ok(await _employeeRepository.GetEmployees());
        }
    }
}