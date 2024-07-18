using ATSAPPBACKEND.DAL;
using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATSAPPBACKEND.Repositories.Classes
{
    public class EMPLOYERCOMPANYREPOSITORY : IEMPLOYERCOMPANYREPOSITORY
    {
        private readonly AppDbContext _dbContext;
        public EMPLOYERCOMPANYREPOSITORY(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddEMPLOYERCOMPANY(EMPLOYERCOMPANY employeeCompany)
        {
            if (employeeCompany != null)
            {
                employeeCompany.EMPLOYERCOMPANYCT = DateTime.Now.TimeOfDay;
                employeeCompany.EMPLOYERCOMPANYCD = DateTime.Today;
                await _dbContext.AddAsync(employeeCompany);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteEMPLOYERCOMPANY(EMPLOYERCOMPANY employeeCompany)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = employeeCompany.EMPLOYERCOMPANYID;
            var empComp = await GetByIdAsync(kv);
            if(empComp != null)
            {
                employeeCompany.DeleteFlag = ActiveDelete.Yes;
                employeeCompany.ActiveFlag = ActiveDelete.No;
                employeeCompany.EMPLOYERCOMPANYUT = DateTime.Now.TimeOfDay;
                employeeCompany.EMPLOYERCOMPANYUD = DateTime.Today;
                _dbContext.Entry<EMPLOYERCOMPANY>(employeeCompany).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() > 0;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<EMPLOYERCOMPANY>> GetEMPLOYERCOMPANIES()
        {
            var empComps = await _dbContext.EMPLOYERCOMPANIES.Where(x => x.ActiveFlag == ActiveDelete.Yes 
                                                                    && x.DeleteFlag == ActiveDelete.No).
                                                                    OrderByDescending(x=>x.EMPLOYERCOMPANYID).ToListAsync();
            return empComps;
        }

        public async Task<List<EMPLOYERCOMPANY>> GetEMPLOYERCOMPANIESBYNAME(KeyValue kv)
        {
            var empComps = await _dbContext.EMPLOYERCOMPANIES.Where(x => x.EMPLOYERCOMPANYNAME.Contains(kv.VALUE1) 
                                                                    && x.ActiveFlag == ActiveDelete.Yes 
                                                                    && x.DeleteFlag == ActiveDelete.No).OrderBy(x=>x.EMPLOYERCOMPANYNAME).ToListAsync();
            return empComps;
        }

        public async Task<EMPLOYERCOMPANY> GetEMPLOYERCOMPANYBYID(KeyValue kv)
        {
            var empComp = await GetByIdAsync(kv);
            return empComp;
        }

        public async Task<bool> UpdateEMPLOYERCOMPANY(EMPLOYERCOMPANY employeeCompany)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = employeeCompany.EMPLOYERCOMPANYID;
            var empComp = await GetByIdAsync(kv);
            if (empComp != null)
            {
                employeeCompany.EMPLOYERCOMPANYUT = DateTime.Now.TimeOfDay;
                employeeCompany.EMPLOYERCOMPANYUD = DateTime.Today;
                _dbContext.Entry<EMPLOYERCOMPANY>(employeeCompany).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() > 0;
            }
            else
            {
                return false;
            }
        }

        private async Task<EMPLOYERCOMPANY> GetByIdAsync(KeyValue kv)
        {
            var empComp = await _dbContext.EMPLOYERCOMPANIES.FirstOrDefaultAsync(x => x.EMPLOYERCOMPANYID == kv.KEY1 
                                                                                && x.ActiveFlag == ActiveDelete.Yes 
                                                                                && x.DeleteFlag == ActiveDelete.No);
            return empComp != null ? empComp : null;
        }
    }
}
