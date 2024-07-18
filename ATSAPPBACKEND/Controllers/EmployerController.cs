using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATSAPPBACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEMPLOYERRESPOSITORY _employerRepository;

        public EmployerController(IEMPLOYERRESPOSITORY employerRepository)
        {
            _employerRepository = employerRepository;
        }

        [HttpPost("GetAllEmployers")]
        public async Task<List<EMPLOYEREXT>> GetAllEmployers()
        {
            var employers = await _employerRepository.GetEMPLOYERS();
            return employers;
        }

        [HttpPost("GetEmployerById")]
        public async Task<EMPLOYEREXT> GetEmployerById([FromBody] KeyValue kv)
        {
            var employer = await _employerRepository.GetEMPLOYERBYID(kv);
            return employer;
        }

        [HttpPost("GetEmployersByName")]
        public async Task<List<EMPLOYEREXT>> GetEmployersByName([FromBody] KeyValue kv)
        {
            var employers = await _employerRepository.GetEMPLOYERSBYNAME(kv);
            return employers;
        }

        [HttpPost("AddOrUpdateEmployer")]
        public async Task<bool> AddOrUpdateEmployer([FromBody] EMPLOYER employer)
        {
            if (ModelState.IsValid)
            {
                if(employer.EMPLOYERID != 0)
                {
                    return await _employerRepository.UpdateEMPLOYER(employer);
                }
                else
                {
                    return await _employerRepository.AddEMPLOYER(employer);
                }
            }else { return false; }
        }

        [HttpPost("DeleteEmployer")]
        public async Task<bool> DeleteEmployer([FromBody] EMPLOYER employer)
        {
            return await _employerRepository.DeleteEMPLOYER(employer);
        }
    }
}
