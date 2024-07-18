using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATSAPPBACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementController : ControllerBase
    {
        private readonly IREQUIREMENTREPOSITORY _requirementRepository;

        public RequirementController(IREQUIREMENTREPOSITORY requirementRepository)
        {
            _requirementRepository = requirementRepository;
        }

        [HttpPost("GetAllRequirements")]
        public async Task<List<ReqVisa>> GetAllRequirements()
        {
            var requirements = await _requirementRepository.GetREQUIREMENTS();
            return requirements;
        }

        [HttpPost("GetRequirementById")]
        public async Task<ReqVisa> GetRequirementById([FromBody] KeyValue kv)
        {
            var requirement = await _requirementRepository.GetREQUIREMENTBYID(kv);
            return requirement;
        }

        [HttpPost("GetRequirementByName")]
        public async Task<List<ReqVisa>> GetRequirementByName([FromBody] KeyValue kv)
        {
            var requirements = await _requirementRepository.GetREQUIREMENTBYNAME(kv);
            return requirements;
        }

        [HttpPost("AddOrUpdateRequirement")]
        public async Task<bool> AddOrUpdateRequirement([FromBody] ReqVisa requirement)
        {
            if(ModelState.IsValid)
            {
                if(requirement.RequiredVisaExt.REQUIREMENTID != 0)
                {
                    return await _requirementRepository.UpdateREQUIREMENT(requirement);
                }
                else
                {
                    return await _requirementRepository.AddREQUIREMENT(requirement);
                }
            }
            else { return false; }
        }

        [HttpPost("DeleteRequirement")]
        public async Task<bool> DeleteRequirement([FromBody] ReqVisa requirement)
        {
            return await _requirementRepository.DeleteREQUIREMENT(requirement);
        }
    }
}
