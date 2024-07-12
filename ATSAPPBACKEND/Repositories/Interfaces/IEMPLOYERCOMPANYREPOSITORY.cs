using ATSAPPBACKEND.Models;

namespace ATSAPPBACKEND.Repositories.Interfaces
{
    public interface IEMPLOYERCOMPANYREPOSITORY
    {
        Task<List<EMPLOYERCOMPANY>> GetEMPLOYERCOMPANIES();
        Task<EMPLOYERCOMPANY> GetEMPLOYERCOMPANYBYID(KeyValue kv);
        Task<List<EMPLOYERCOMPANY>> GetEMPLOYERCOMPANIESBYNAME(KeyValue kv);
        Task<bool> AddEMPLOYERCOMPANY(EMPLOYERCOMPANY employeeCompany);
        Task<bool> UpdateEMPLOYERCOMPANY(EMPLOYERCOMPANY employeeCompany);
        Task<bool> DeleteEMPLOYERCOMPANY(EMPLOYERCOMPANY employeeCompany);
    }
}
