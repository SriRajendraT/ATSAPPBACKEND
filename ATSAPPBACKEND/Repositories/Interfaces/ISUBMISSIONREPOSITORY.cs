using ATSAPPBACKEND.Models;

namespace ATSAPPBACKEND.Repositories.Interfaces
{
    public interface ISUBMISSIONREPOSITORY
    {
        Task<List<SUBMISSIONEXT>> GETSUBMISSIONS();
        Task<SUBMISSIONEXT> GETSUBMISSIONBYID(KeyValue kv);
        Task<List<SUBMISSIONEXT>> GETSUBMISSIONBYNAME(KeyValue kv);
        Task<bool> ADDSUBMISSION(SUBMISSION submission);
        Task<bool> UPDATESUBMISSION(SUBMISSION submission);
        Task<bool> DELETESUBMISSION(SUBMISSION submission);
    }
}
