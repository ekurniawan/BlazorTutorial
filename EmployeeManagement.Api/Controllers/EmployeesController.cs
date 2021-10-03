using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult> GetEmployees(){
            return Ok(await _employeeRepository.GetEmployees());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id){
            var result = await _employeeRepository.GetEmployee(id);
            if(result==null) return NotFound();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreteEmployee(Employee employee){
            try{
                if(employee==null)
                    return BadRequest();
                
                var createdEmployee = await _employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee),
                    new {id=createdEmployee.EmployeeId},createdEmployee);
            }catch(Exception ex){
                return StatusCode(500,$"Gagal membuat employee baru {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee){
            try{
                if(id!=employee.EmployeeId)
                    return BadRequest("Employee ID tidak sama");
                var employeeToUpdate = await _employeeRepository.GetEmployee(id);
                if(employeeToUpdate!=null)
                    return await _employeeRepository.UpdateEmployee(employee);
                else
                    return BadRequest("Employee ID tidak ditemukan");
            }catch(Exception ex){
                return StatusCode(500,$"Gagal update data {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id){
            try{
                var employeeToDelete = await _employeeRepository.GetEmployee(id);
                if(employeeToDelete==null){
                    return NotFound($"Employee dengan Id {id} tidak ditemukan");
                }

                return await _employeeRepository.DeleteEmployee(id);

            }catch(Exception ex){
                return StatusCode(500,$"Gagal delete data {ex.Message}");
            }
        }

        //menambahkan search employee
        [HttpGet("{search}/{name}/{gender?}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name,Gender? gender){
            try{
                var result = await _employeeRepository.Search(name,gender);
                if(result.Any()){
                    return Ok(result);
                }
                return NotFound();
            }
            catch(Exception){
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error untuk menampilkan data dari database");
            }
        }
    }
}