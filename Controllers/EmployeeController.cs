using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dapperTest.Controllers {

    [ApiController]
    [Route ("[controller]")]
    public class EmployeesController : ControllerBase {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeesController (IEmployeeRepository employeeRepo) {
            _employeeRepo = employeeRepo;
        }

        [HttpGet ()]
        public async Task<IActionResult> GetEmployees () {
            try {
                var employees = await _employeeRepo.GetEmployees ();
                return Ok (employees);
            } catch (Exception ex) {
                //log error
                return StatusCode (500, ex.Message);
            }
        }

        [HttpGet ("{id}", Name = "EmployeeById")]
        public async Task<IActionResult> GetEmployee (int id) {
            try {
                var employee = await _employeeRepo.GetEmployee (id);

                if (employee == null) {
                    return NotFound ();
                }

                return Ok (employee);
            } catch (Exception ex) {
                //log error
                return StatusCode (500, ex.Message);
            }
        }

        [HttpGet ("{id}/raw", Name = "EmployeeByIdWithoutRelations")]
        public async Task<IActionResult> GetEmployeeWithoutRelations (int id) {
            try {
                var employee = await _employeeRepo.GetEmployeeWithoutRelations (id);

                if (employee == null) {
                    return NotFound ();
                }

                return Ok (employee);
            } catch (Exception ex) {
                //log error
                return StatusCode (500, ex.Message);
            }
        }
    }
}