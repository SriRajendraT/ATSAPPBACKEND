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
    }
}
