using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATSAPPBACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICANDIDATEREPOSITORY _candidateRepository;

        public CandidateController(ICANDIDATEREPOSITORY candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        [HttpPost("GetAllCandidate")]
        public async Task<List<CANDIDATEEXT>> GetAllCandidate()
        {
            var candidates = await _candidateRepository.GetCANDIDATES();
            return candidates;
        }

        [HttpPost("GetCandidateById")]
        public async Task<CANDIDATEEXT> GetCandidateById([FromBody] KeyValue kv)
        {
            var candidate = await _candidateRepository.GetCANDIDATEBYID(kv);
            return candidate;
        }

        [HttpPost("GetCandiatesByName")]
        public async Task<List<CANDIDATEEXT>> GetCandiatesByName([FromBody] KeyValue kv)
        {
            var candidates = await _candidateRepository.GetCANDIDATESBYNAME(kv);
            return candidates;
        }

        [HttpPost("AddOrUpdateCandidate")]
        public async Task<bool> AddOrUpdateCandidate([FromBody] CANDIDATE candidate)
        {
            if (ModelState.IsValid)
            {
                if(candidate.CANDIDATEID != 0)
                {
                    return await _candidateRepository.UpdateCANDIDATE(candidate);
                }
                else { return await _candidateRepository.AddCANDIDATE(candidate); }
            }
            else { return false; }
        }

        [HttpPost("DeleteCandidate")]
        public async Task<bool> DeleteCandidate([FromBody] CANDIDATE candidate)
        {
            return await _candidateRepository.DeleteCANDIDATE(candidate);
        }
    }
}
