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
using CompanyAPI.WebAPI.Models.DTO;

namespace CompanyAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly CompanyAPIContext _context;
        private readonly ICompanyService _companyService;

        public CompaniesController(CompanyAPIContext context, ICompanyService companyService)
        {
            _context = context;
            _companyService = companyService;
        }

        // GET: api/Companies
        [HttpGet]
        public IEnumerable<CompanyDTO> GetCompanies()
        {
            if (_context.Company == null)
            {
                return null;
            }
            return _companyService.GetCompanies();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            var company = _companyService.GetCompany(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public IActionResult UpdateCompany(CompanyDTO company)
        {
            var companyToUpdate = _companyService.GetCompany(company.CompanyId);
            if (companyToUpdate == null)
            {
                return NotFound();
            }
            _companyService.UpdateCompany(company);
            return NoContent();

        }

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult AddCompany(CompanyDTO company)
        {
            _companyService.AddCompany(company);
            return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompanyById(int id)
        {
            _companyService.DeleteCompanyById(id);
            return NoContent();

        }

        private bool CompanyExists(int id)
        {
            return (_context.Company?.Any(e => e.CompanyId == id)).GetValueOrDefault();
        }
    }
}
