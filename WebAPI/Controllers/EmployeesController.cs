using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyAPI.Data;
using CompanyAPI.Models;
using CompanyAPI.Service.Interfaces;
using CompanyAPI.Service;
using CompanyAPI.WebAPI.Models.DTO;

namespace CompanyAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CompanyAPIContext _context;
        private readonly IEmployeeService _employeeService;
        public EmployeesController(CompanyAPIContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult GetEmployees()
        {
            _employeeService.GetEmployees();
            return Ok();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            _employeeService.GetEmployee(id);
            return Ok();
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(EmployeeDTO employee)
        {
            _employeeService.UpdateEmployee(employee);
            return NoContent();
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult AddEmployee(EmployeeDTO employee)
        {
            _employeeService.AddEmployee(employee);
            return Ok();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployeeById(id);
            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employee?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
