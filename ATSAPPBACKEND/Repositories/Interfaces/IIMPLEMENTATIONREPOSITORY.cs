using ATSAPPBACKEND.Models;

namespace ATSAPPBACKEND.Repositories.Interfaces
{
    public interface IIMPLEMENTATIONREPOSITORY
    {
        Task<List<IMPLEMENTATION>> GetIMPLEMENTATIONS();
        Task<List<IMPLEMENTATION>> GetIMPLEMENTATIONBYNAME(KeyValue kv);
        Task<IMPLEMENTATION> GetIMPLEMENTATIONBYID(KeyValue kv);
        Task<bool> AddIMPLEMENTATION(IMPLEMENTATION implementation);
        Task<bool> UpdateIMPLEMENTATION(IMPLEMENTATION implementation);
        Task<bool> DeleteIMPLEMENTATION(IMPLEMENTATION implementation);
    }
}
