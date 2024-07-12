using ATSAPPBACKEND.Models;

namespace ATSAPPBACKEND.Repositories.Interfaces
{
    public interface ICLIENTREPOSITORY
    {
        Task<List<CLIENT>> GetCLIENTS();
        Task<CLIENT> GetCLIENTSBYID(KeyValue kv);
        Task<List<CLIENT>> GetCLIENTSBYNAME(KeyValue kv);
        Task<bool> AddCLIENT(CLIENT client);
        Task<bool> UpdateCLIENT(CLIENT client);
        Task<bool> DeleteCLIENT(CLIENT client);
    }
}
