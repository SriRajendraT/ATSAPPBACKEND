using ATSAPPBACKEND.Models;

namespace ATSAPPBACKEND.Repositories.Interfaces
{
    public interface IEMPLOYERRESPOSITORY
    {
        Task<List<EMPLOYEREXT>> GetEMPLOYERS();
        Task<EMPLOYEREXT> GetEMPLOYERBYID(KeyValue kv);
        Task<List<EMPLOYEREXT>> GetEMPLOYERSBYNAME(KeyValue kv);
        Task<bool> AddEMPLOYER(EMPLOYER employer);
        Task<bool> UpdateEMPLOYER(EMPLOYER employer);
        Task<bool> DeleteEMPLOYER(EMPLOYER employer);
    }
}
