using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dapperTest.Controllers {

    [ApiController]
    [Route ("[controller]")]
    public class CompaniesController : ControllerBase {

        private readonly ICompanyRepository _companyRepo;

        public CompaniesController (ICompanyRepository companyRepo) {
            _companyRepo = companyRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies () {
            try {
                var companies = await _companyRepo.GetCompanies ();
                return Ok (companies);
            } catch (Exception ex) {
                //log error
                return StatusCode (500, ex.Message);
            }
        }

        [HttpGet ("{id}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany (int id) {
            try {
                var company = await _companyRepo.GetCompany (id);
                if (company == null)
                    return NotFound ();
                return Ok (company);
            } catch (Exception ex) {
                //log error
                return StatusCode (500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany (CreateCompanyDto company) {
            try {
                var createdCompany = await _companyRepo.CreateCompany (company);
                return CreatedAtRoute ("CompanyById", new { id = createdCompany.Id }, createdCompany);
            } catch (Exception ex) {
                //log error
                return StatusCode (500, ex.Message);
            }
        }
    }
}