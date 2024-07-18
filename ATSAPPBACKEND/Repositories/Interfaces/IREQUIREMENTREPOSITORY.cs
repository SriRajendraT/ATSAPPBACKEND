using ATSAPPBACKEND.Models;

namespace ATSAPPBACKEND.Repositories.Interfaces
{
    public interface IREQUIREMENTREPOSITORY
    {
        Task<List<ReqVisa>> GetREQUIREMENTS();
        Task<ReqVisa> GetREQUIREMENTBYID(KeyValue kv);
        Task<List<ReqVisa>> GetREQUIREMENTBYNAME(KeyValue kv);
        Task<bool> AddREQUIREMENT(ReqVisa requirement);
        Task<bool> UpdateREQUIREMENT(ReqVisa requirement);
        Task<bool> DeleteREQUIREMENT(ReqVisa requirement);
    }
}
