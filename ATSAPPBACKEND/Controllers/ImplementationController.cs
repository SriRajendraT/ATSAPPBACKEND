using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATSAPPBACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImplementationController : ControllerBase
    {
        private readonly IIMPLEMENTATIONREPOSITORY _implementationRepository;

        public ImplementationController(IIMPLEMENTATIONREPOSITORY implementationRepository)
        {
            _implementationRepository = implementationRepository;
        }

        [HttpPost("GetAllImplementation")]
        public async Task<List<IMPLEMENTATION>> GetAllImplementation()
        {
            var implementations = await _implementationRepository.GetIMPLEMENTATIONS();
            return implementations;
        }

        [HttpPost("GetImplementationById")]
        public async Task<IMPLEMENTATION> GetImplementationById([FromBody] KeyValue kv)
        {
            var implementation = await _implementationRepository.GetIMPLEMENTATIONBYID(kv);
            return implementation;
        }

        [HttpPost("GetImplementationByName")]
        public async Task<List<IMPLEMENTATION>> GetImplementationByName([FromBody] KeyValue kv) 
        {
            var implementations = await _implementationRepository.GetIMPLEMENTATIONBYNAME(kv);
            return implementations;
        }

        [HttpPost("AddOrUpdateImplementation")]
        public async Task<bool> AddOrUpdateImplementation([FromBody] IMPLEMENTATION implementation)
        {
            if (ModelState.IsValid)
            {
                if(implementation.IMPLEMENTATIONID != 0)
                {
                    return await _implementationRepository.UpdateIMPLEMENTATION(implementation);
                }
                else
                { 
                    return await _implementationRepository.AddIMPLEMENTATION(implementation);
                }
            }
            else { return false; }
        }

        [HttpPost("DeleteImplementation")]
        public async Task<bool> DeleteImplementation([FromBody] IMPLEMENTATION implementation)
        {
            return await _implementationRepository.DeleteIMPLEMENTATION(implementation);
        }
    }
}
