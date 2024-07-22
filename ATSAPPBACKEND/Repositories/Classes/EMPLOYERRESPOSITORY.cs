using ATSAPPBACKEND.DAL;
using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATSAPPBACKEND.Repositories.Classes
{
    public class EMPLOYERRESPOSITORY : IEMPLOYERRESPOSITORY
    {
        private readonly AppDbContext _dbContext;

        public EMPLOYERRESPOSITORY(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddEMPLOYER(EMPLOYER employer)
        {
            try
            {
                if (employer != null)
                {
                    employer.EMPLOYERCD=DateTime.Now;
                    employer.EMPLOYERCT = DateTime.Now.TimeOfDay;
                    employer.ActiveFlag = ActiveDelete.Yes;
                    employer.DeleteFlag = ActiveDelete.No;
                    _dbContext.EMPLOYERS.Add(employer);
                    return await _dbContext.SaveChangesAsync() > 0;
                }else
                {
                    return false;
                }
            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEMPLOYER(EMPLOYER employer)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = employer.EMPLOYERID;

            try
            {
                var emp = await GetById(kv);
                if (emp != null)
                {
                    employer.EMPLOYERUD = DateTime.Now;
                    employer.EMPLOYERUT = DateTime.Now.TimeOfDay;
                    employer.ActiveFlag = ActiveDelete.No;
                    employer.DeleteFlag = ActiveDelete.Yes;
                    _dbContext.Entry<EMPLOYER>(employer).State = EntityState.Modified;
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else { return false; }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<EMPLOYEREXT> GetEMPLOYERBYID(KeyValue kv)
        {
            var emp = await GetById(kv);
            return emp;
        }

        public async Task<List<EMPLOYEREXT>> GetEMPLOYERS()
        {
            try
            {
                var employers = await (from emp in _dbContext.EMPLOYERS
                                       join ec in _dbContext.EMPLOYERCOMPANIES on emp.EMPLOYERCOMPANY equals ec.EMPLOYERCOMPANYID

                                       where emp.ActiveFlag == ActiveDelete.Yes && emp.DeleteFlag == ActiveDelete.No

                                       select new EMPLOYEREXT
                                       {
                                           EMPLOYERID = emp.EMPLOYERID,
                                           EMPLOYERNAME = emp.EMPLOYERNAME,
                                           EMPLOYERCD = emp.EMPLOYERCD,
                                           EMPLOYERCT = emp.EMPLOYERCT,
                                           EMPLOYERUD = emp.EMPLOYERUD,
                                           EMPLOYERUT = emp.EMPLOYERUT,
                                           EMPLOYERCOMPANY = emp.EMPLOYERCOMPANY,
                                           EMPLOYEREMAIL = emp.EMPLOYEREMAIL,
                                           EMPLOYERPHONENUMBER = emp.EMPLOYERPHONENUMBER,
                                           ActiveFlag = emp.ActiveFlag,
                                           DeleteFlag = emp.DeleteFlag,
                                           EMPLOYERCOMPANYNAME = ec.EMPLOYERCOMPANYNAME
                                       }).OrderByDescending(x=>x.EMPLOYERID).ToListAsync();
                return employers;
            }catch(Exception ex) { return null; }
        }

        public async Task<List<EMPLOYEREXT>> GetEMPLOYERSBYNAME(KeyValue kv)
        {
            try
            {
                var em = await (from emp in _dbContext.EMPLOYERS
                                join ec in _dbContext.EMPLOYERCOMPANIES on emp.EMPLOYERCOMPANY equals ec.EMPLOYERCOMPANYID

                                where emp.EMPLOYERNAME.Contains(kv.VALUE1) && emp.ActiveFlag == ActiveDelete.Yes && emp.DeleteFlag == ActiveDelete.No

                                select new EMPLOYEREXT
                                {
                                    EMPLOYERID = emp.EMPLOYERID,
                                    EMPLOYERNAME = emp.EMPLOYERNAME,
                                    EMPLOYERCD = emp.EMPLOYERCD,
                                    EMPLOYERCT = emp.EMPLOYERCT,
                                    EMPLOYERUD = emp.EMPLOYERUD,
                                    EMPLOYERUT = emp.EMPLOYERUT,
                                    EMPLOYERCOMPANY = emp.EMPLOYERCOMPANY,
                                    EMPLOYEREMAIL = emp.EMPLOYEREMAIL,
                                    EMPLOYERPHONENUMBER = emp.EMPLOYERPHONENUMBER,
                                    ActiveFlag = emp.ActiveFlag,
                                    DeleteFlag = emp.DeleteFlag,
                                    EMPLOYERCOMPANYNAME = ec.EMPLOYERCOMPANYNAME
                                }).OrderBy(x=>x.EMPLOYERCOMPANYNAME).ToListAsync();
                return em;
            }
            catch(Exception ex) { return null; }
        }

        public async Task<bool> UpdateEMPLOYER(EMPLOYER employer)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = employer.EMPLOYERID;
            try
            {
                var emp = await GetById(kv);
                if (emp != null)
                {
                    employer.ActiveFlag = emp.ActiveFlag;
                    employer.DeleteFlag = emp.DeleteFlag;
                    employer.EMPLOYERCD = emp.EMPLOYERCD;
                    employer.EMPLOYERCT = emp.EMPLOYERCT;
                    employer.EMPLOYERUD = DateTime.Now;
                    employer.EMPLOYERUT = DateTime.Now.TimeOfDay;
                    _dbContext.Entry<EMPLOYER>(employer).State = EntityState.Modified;
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else {  return false; }
            }
            catch(Exception ex) { return false; }
        }

        private async Task<EMPLOYEREXT> GetById(KeyValue kv)
        {
            try
            {
                var em = await (from emp in _dbContext.EMPLOYERS
                                join ec in _dbContext.EMPLOYERCOMPANIES on emp.EMPLOYERCOMPANY equals ec.EMPLOYERCOMPANYID

                                where emp.EMPLOYERID == kv.KEY1 && emp.ActiveFlag == ActiveDelete.Yes && emp.DeleteFlag == ActiveDelete.No

                                select new EMPLOYEREXT
                                {
                                    EMPLOYERID = emp.EMPLOYERID,
                                    EMPLOYERNAME = emp.EMPLOYERNAME,
                                    EMPLOYERCD = emp.EMPLOYERCD,
                                    EMPLOYERCT = emp.EMPLOYERCT,
                                    EMPLOYERUD = emp.EMPLOYERUD,
                                    EMPLOYERUT = emp.EMPLOYERUT,
                                    EMPLOYERCOMPANY = emp.EMPLOYERCOMPANY,
                                    EMPLOYEREMAIL = emp.EMPLOYEREMAIL,
                                    EMPLOYERPHONENUMBER = emp.EMPLOYERPHONENUMBER,
                                    ActiveFlag = emp.ActiveFlag,
                                    DeleteFlag = emp.DeleteFlag,
                                    EMPLOYERCOMPANYNAME = ec.EMPLOYERCOMPANYNAME
                                }).AsNoTracking().FirstOrDefaultAsync();
                return em;
            }
            catch(Exception ex) { return null; }
        }
    }
}
