using ATSAPPBACKEND.DAL;
using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATSAPPBACKEND.Repositories.Classes
{
    public class IMPLEMENTATIONREPOSITORY : IIMPLEMENTATIONREPOSITORY
    {
        private readonly AppDbContext _dbContext;

        public IMPLEMENTATIONREPOSITORY(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddIMPLEMENTATION(IMPLEMENTATION implementation)
        {
            if (implementation != null)
            {
                implementation.ActiveFlag = ActiveDelete.Yes;
                implementation.DeleteFlag = ActiveDelete.No;
                implementation.IMPLEMENTATIONCD = DateTime.Now;
                implementation.IMPLEMENTATIONCT = DateTime.Now.TimeOfDay;
                await _dbContext.AddAsync(implementation);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            else { return false; }
        }

        public async Task<bool> DeleteIMPLEMENTATION(IMPLEMENTATION implementation)
        {
            try
            {
                KeyValue kv = new KeyValue();
                kv.KEY1 = implementation.IMPLEMENTATIONID;
                var impl = GetByIdAsync(kv);
                if (impl != null)
                {
                    implementation.ActiveFlag = ActiveDelete.No;
                    implementation.DeleteFlag = ActiveDelete.Yes;
                    implementation.IMPLEMENTATIONUD = DateTime.Now;
                    implementation.IMPLEMENTATIONUT = DateTime.Now.TimeOfDay;
                    _dbContext.Entry<IMPLEMENTATION>(implementation).State = EntityState.Modified;
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IMPLEMENTATION> GetIMPLEMENTATIONBYID(KeyValue kv)
        {
            var implementation = await GetByIdAsync(kv);
            return implementation;
        }

        public async Task<List<IMPLEMENTATION>> GetIMPLEMENTATIONBYNAME(KeyValue kv)
        {
            var implementations = await _dbContext.IMPLEMENTATIONS.Where(x => x.IMPLEMENTATIONNAME.Contains(kv.VALUE1) &&
                                                                            x.ActiveFlag == ActiveDelete.Yes &&
                                                                            x.DeleteFlag == ActiveDelete.No)
                                                                .OrderBy(x => x.IMPLEMENTATIONNAME).ToListAsync();
            return implementations;
        }

        public async Task<List<IMPLEMENTATION>> GetIMPLEMENTATIONS()
        {
            var implementations = await _dbContext.IMPLEMENTATIONS.Where(x => x.ActiveFlag == ActiveDelete.Yes &&
                                                                        x.DeleteFlag == ActiveDelete.No)
                                                                        .OrderByDescending(x => x.IMPLEMENTATIONID).ToListAsync();
            return implementations;
        }

        public async Task<bool> UpdateIMPLEMENTATION(IMPLEMENTATION implementation)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = implementation.IMPLEMENTATIONID;
            var impl = await GetByIdAsync(kv);
            if (impl != null)
            {
                implementation.ActiveFlag = impl.ActiveFlag;
                implementation.DeleteFlag = impl.DeleteFlag;
                implementation.IMPLEMENTATIONCD = impl.IMPLEMENTATIONCD;
                implementation.IMPLEMENTATIONCT = impl.IMPLEMENTATIONCT;
                implementation.IMPLEMENTATIONUD = DateTime.Now;
                implementation.IMPLEMENTATIONUT = DateTime.Now.TimeOfDay;
                _dbContext.Entry<IMPLEMENTATION>(implementation).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() > 0;
            }
            else { return false; }
        }

        private async Task<IMPLEMENTATION> GetByIdAsync(KeyValue kv)
        {
            var implementation = await _dbContext.IMPLEMENTATIONS.AsNoTracking().Where(x => x.IMPLEMENTATIONID == kv.KEY1 &&
                                                                           x.ActiveFlag == ActiveDelete.Yes &&
                                                                           x.DeleteFlag == ActiveDelete.No).FirstOrDefaultAsync();
            return implementation != null ? implementation : null;
        }
    }
}
