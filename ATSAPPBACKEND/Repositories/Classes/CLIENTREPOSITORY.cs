using ATSAPPBACKEND.DAL;
using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATSAPPBACKEND.Repositories.Classes
{
    public class CLIENTREPOSITORY : ICLIENTREPOSITORY
    {
        private readonly AppDbContext _dbContext;

        public CLIENTREPOSITORY(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddCLIENT(CLIENT client)
        {
            if (client != null)
            {
                client.ActiveFlag = ActiveDelete.Yes;
                client.DeleteFlag = ActiveDelete.No;
                client.CLIENTCD = DateTime.Now;
                client.CLIENTCT = DateTime.Now.TimeOfDay;
                await _dbContext.AddAsync(client);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteCLIENT(CLIENT client)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = client.CLIENTID;
            var cli = await GetByIdAsync(kv);
            if (cli != null)
            {
                client.ActiveFlag = ActiveDelete.No;
                client.DeleteFlag = ActiveDelete.Yes;
                client.CLIENTUD = DateTime.Now;
                client.CLIENTUT = DateTime.Now.TimeOfDay;
                _dbContext.Entry<CLIENT>(client).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync() > 0;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<CLIENT>> GetCLIENTS()
        {
            var clients = await _dbContext.CLIENTS.Where(x => x.ActiveFlag == ActiveDelete.Yes
                                                           && x.DeleteFlag == ActiveDelete.No).OrderByDescending(x => x.CLIENTID).ToListAsync();
            return clients;
        }

        public async Task<CLIENT> GetCLIENTSBYID(KeyValue kv)
        {
            var client = await GetByIdAsync(kv);
            return client;
        }

        public async Task<List<CLIENT>> GetCLIENTSBYNAME(KeyValue kv)
        {
            var clients = await _dbContext.CLIENTS.Where(x => x.CLIENTNAME.Contains(kv.VALUE1) &&
                                                                x.ActiveFlag == ActiveDelete.Yes &&
                                                                x.DeleteFlag == ActiveDelete.No).OrderBy(x => x.CLIENTNAME).ToListAsync();
            return clients;
        }

        public async Task<bool> UpdateCLIENT(CLIENT client)
        {
            try
            {
                KeyValue kv = new KeyValue();
                kv.KEY1 = client.CLIENTID;
                var cli = await GetByIdAsync(kv);
                if (cli != null)
                {
                    client.ActiveFlag = cli.ActiveFlag;
                    client.DeleteFlag = cli.DeleteFlag;
                    client.CLIENTCD = cli.CLIENTCD;
                    client.CLIENTCT = cli.CLIENTCT;
                    client.CLIENTUD = DateTime.Now;
                    client.CLIENTUT = DateTime.Now.TimeOfDay;
                    _dbContext.Entry<CLIENT>(client).State = EntityState.Modified;
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<CLIENT> GetByIdAsync(KeyValue kv)
        {
            var client = await _dbContext.CLIENTS.AsNoTracking().FirstOrDefaultAsync(x => x.CLIENTID == kv.KEY1
                                                                        && x.ActiveFlag == ActiveDelete.Yes
                                                                        && x.DeleteFlag == ActiveDelete.No);
            return client != null ? client : null;
        }
    }
}
