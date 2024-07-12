using ATSAPPBACKEND.Models;

namespace ATSAPPBACKEND.Repositories.Interfaces
{
    public interface IBASICGETS
    {
        Task<List<GENDER>> GetGENDER();
        Task<List<COUNTRY>> GetCOUNTRIES();
        Task<List<STATE>> GetSTATES(KeyValue kv);
        Task<List<CITY>> GetCITIES(KeyValue kv);
        Task<List<VISA>> GetVISAS();
        Task<List<TAXTERM>> GetTAXTERMS();
        Task<List<WORKNATURE>> GetWORKNATURES();
        Task<List<HYBRIDTYPE>> GetHYBRIDTYPES();
        Task<List<SUBMISSIONSTATUS>> GetSUBMISSIONSTATUSES();
    }
}
