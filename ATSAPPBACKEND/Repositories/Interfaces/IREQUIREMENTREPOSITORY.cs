using ATSAPPBACKEND.Models;

namespace ATSAPPBACKEND.Repositories.Interfaces
{
    public interface IREQUIREMENTREPOSITORY
    {
        Task<List<REQUIREMENTEXT>> GetREQUIREMENTS();
        Task<REQUIREMENTEXT> GetREQUIREMENTBYID(KeyValue kv);
        Task<List<REQUIREMENTEXT>> GetREQUIREMENTBYNAME(KeyValue kv);
        Task<bool> AddREQUIREMENT(ReqVisa requirement);
        Task<bool> UpdateREQUIREMENT(ReqVisa requirement);
        Task<bool> DeleteREQUIREMENT(ReqVisa requirement);
    }
}
