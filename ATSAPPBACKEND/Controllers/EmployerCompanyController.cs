using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATSAPPBACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerCompanyController : ControllerBase
    {
        private readonly IEMPLOYERCOMPANYREPOSITORY _employerCompanyRepository;

        public EmployerCompanyController(IEMPLOYERCOMPANYREPOSITORY employerCompanyRepository)
        {
            _employerCompanyRepository = employerCompanyRepository;
        }

        [HttpPost("GetAllEmployerCompanies")]
        public async Task<List<EMPLOYERCOMPANY>> GetAllEmployerCompanies()
        {
            var employerCompanies = await _employerCompanyRepository.GetEMPLOYERCOMPANIES();
            return employerCompanies;
        }

        [HttpPost("GetEmployerCompanyById")]
        public async Task<EMPLOYERCOMPANY> GetEmployerCompanyById([FromBody] KeyValue kv)
        {
            var employerCompany = await _employerCompanyRepository.GetEMPLOYERCOMPANYBYID(kv);
            return employerCompany;
        }

        [HttpPost("GetEmployerCompaniesByName")]
        public async Task<List<EMPLOYERCOMPANY>> GetEmployerCompaniesByName([FromBody] KeyValue kv)
        {
            var employerCompanies = await _employerCompanyRepository.GetEMPLOYERCOMPANIESBYNAME(kv);
            return employerCompanies;
        }

        [HttpPost("AddOrUpdateEmployerCompany")]
        public async Task<bool> AddOrUpdateEmployerCompany([FromBody] EMPLOYERCOMPANY employerCompany)
        {
            if (ModelState.IsValid)
            {
                if (employerCompany.EMPLOYERCOMPANYID != 0)
                {
                    return await _employerCompanyRepository.UpdateEMPLOYERCOMPANY(employerCompany);
                }
                else
                {
                    return await _employerCompanyRepository.AddEMPLOYERCOMPANY(employerCompany);
                }
            }
            else{ return false; }
        }

        [HttpPost("DeleteEmployerCompany")]
        public async Task<bool> DeleteEmployerCompany([FromBody] EMPLOYERCOMPANY employerCompany)
        {
            return await _employerCompanyRepository.DeleteEMPLOYERCOMPANY(employerCompany);
        }
    }
}
