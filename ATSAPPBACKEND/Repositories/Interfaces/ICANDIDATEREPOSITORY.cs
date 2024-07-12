using ATSAPPBACKEND.Models;

namespace ATSAPPBACKEND.Repositories.Interfaces
{
    public interface ICANDIDATEREPOSITORY
    {
        Task<List<CANDIDATEEXT>> GetCANDIDATES();
        Task<CANDIDATEEXT> GetCANDIDATEBYID(KeyValue kv);
        Task<List<CANDIDATEEXT>> GetCANDIDATESBYNAME(KeyValue kv);
        Task<bool> AddCANDIDATE(CANDIDATE candidate);
        Task<bool> UpdateCANDIDATE(CANDIDATE candidate);
        Task<bool> DeleteCANDIDATE(CANDIDATE candidate);
    }
}
