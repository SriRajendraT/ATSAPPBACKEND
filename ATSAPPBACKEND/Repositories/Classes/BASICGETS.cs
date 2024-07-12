using ATSAPPBACKEND.DAL;
using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATSAPPBACKEND.Repositories.Classes
{
    public class BASICGETS : IBASICGETS
    {
        private readonly AppDbContext _dbContext;

        public BASICGETS(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CITY>> GetCITIES(KeyValue kv)
        {
            var cities = await _dbContext.CITIES.Where(x => x.STATEID == kv.KEY1).ToListAsync();
            return cities;
        }

        public async Task<List<COUNTRY>> GetCOUNTRIES()
        {
            var countries = await _dbContext.COUNTRIES.ToListAsync();
            return countries;
        }

        public async Task<List<GENDER>> GetGENDER()
        {
            var genders = await _dbContext.GENDERS.ToListAsync();
            return genders;
        }

        public async Task<List<HYBRIDTYPE>> GetHYBRIDTYPES()
        {
            var hybridtypes = await _dbContext.HYBRIDTYPES.ToListAsync();
            return hybridtypes;
        }

        public async Task<List<STATE>> GetSTATES(KeyValue kv)
        {
            var states = await _dbContext.STATES.Where(x => x.COUNTRYID == kv.KEY1).ToListAsync();
            return states;
        }

        public async Task<List<SUBMISSIONSTATUS>> GetSUBMISSIONSTATUSES()
        {
            var substatus = await _dbContext.SUBMISSIONSTATUSES.ToListAsync();
            return substatus;
        }

        public async Task<List<TAXTERM>> GetTAXTERMS()
        {
            var taxterms = await _dbContext.TAXTERMES.ToListAsync();
            return taxterms;
        }

        public async Task<List<VISA>> GetVISAS()
        {
            var visas = await _dbContext.VISAS.ToListAsync();
            return visas;
        }

        public async Task<List<WORKNATURE>> GetWORKNATURES()
        {
            var wn = await _dbContext.WORKNATURES.ToListAsync();
            return wn;
        }
    }
}
