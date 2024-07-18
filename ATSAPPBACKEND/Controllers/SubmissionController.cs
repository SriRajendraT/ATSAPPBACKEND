using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATSAPPBACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISUBMISSIONREPOSITORY _submissionRepository;

        public SubmissionController(ISUBMISSIONREPOSITORY submissionRepository)
        {
            _submissionRepository = submissionRepository;
        }

        [HttpPost("GetAllSubmissions")]
        public async Task<List<SUBMISSIONEXT>> GetAllSubmissions()
        {
            var submissions = await _submissionRepository.GETSUBMISSIONS();
            return submissions;
        }

        [HttpPost("GetSumissionById")]
        public async Task<SUBMISSIONEXT> GetSumissionById([FromBody] KeyValue kv)
        {
            var submission = await _submissionRepository.GETSUBMISSIONBYID(kv);
            return submission;
        }

        [HttpPost("GetSubmissionsByNames")]
        public async Task<List<SUBMISSIONEXT>> GetSubmissionsByNames([FromBody] KeyValue kv)
        {
            var submissions = await _submissionRepository.GETSUBMISSIONBYNAME(kv);
            return submissions;
        }

        [HttpPost("AddOrUpdateSubmission")]
        public async Task<bool> AddOrUpdateSubmission([FromBody] SUBMISSION submission)
        {
            if (ModelState.IsValid)
            {
                if (submission.SUBMISSIONID != 0)
                {
                    return await _submissionRepository.UPDATESUBMISSION(submission);
                }
                else { return await _submissionRepository.ADDSUBMISSION(submission); }
            }else{ return false; }
        }

        [HttpPost("DeleteSubmission")]
        public async Task<bool> DeleteSubmission([FromBody] SUBMISSION submission)
        {
            return await _submissionRepository.DELETESUBMISSION(submission);
        }
    }
}
