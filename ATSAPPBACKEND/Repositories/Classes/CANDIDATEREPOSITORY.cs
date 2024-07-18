using ATSAPPBACKEND.DAL;
using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATSAPPBACKEND.Repositories.Classes
{
    public class CANDIDATEREPOSITORY : ICANDIDATEREPOSITORY
    {
        private readonly AppDbContext _dbContext;

        public CANDIDATEREPOSITORY(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddCANDIDATE(CANDIDATE candidate)
        {
            try
            {
                if (candidate != null)
                {
                    candidate.ActiveFlag = ActiveDelete.Yes;
                    candidate.DeleteFlag = ActiveDelete.No;
                    candidate.CANDIDATECD = DateTime.Now;
                    candidate.CANDIDATECT = DateTime.Now.TimeOfDay;
                    await _dbContext.CANDIDATES.AddAsync(candidate);
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else { return false; }
            }catch (Exception ex) { return false; }
        }

        public async Task<bool> DeleteCANDIDATE(CANDIDATE candidate)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = candidate.CANDIDATEID;
            try
            {
                var can = await GetById(kv);
                if (can != null)
                {
                    candidate.ActiveFlag = ActiveDelete.No;
                    candidate.DeleteFlag = ActiveDelete.Yes;
                    _dbContext.Entry<CANDIDATE>(candidate).State = EntityState.Modified;
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else { return false; }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<CANDIDATEEXT> GetCANDIDATEBYID(KeyValue kv)
        {
            var candidate = await GetById(kv);
            return candidate;
        }

        public async Task<List<CANDIDATEEXT>> GetCANDIDATES()
        {
            try
            {
                var candidates = await (from can in _dbContext.CANDIDATES
                                        join gnd in _dbContext.GENDERS on can.CANDIDATEGENDER equals gnd.GENDERID
                                        join cnty in _dbContext.COUNTRIES on can.CANDIDATELOCCOUNTRY equals cnty.COUNTRYID
                                        join sta in _dbContext.STATES on can.CANDIDATELOCSTATE equals sta.STATEID
                                        join cty in _dbContext.CITIES on can.CANDIDATELOCCITY equals cty.CITYID
                                        join tt in _dbContext.TAXTERMES on can.CANDIDATETAXTERM equals tt.TAXTERMID
                                        join emp in _dbContext.EMPLOYERS on can.CANDIDATEEMPLOYER equals emp.EMPLOYERID

                                        where can.ActiveFlag == ActiveDelete.Yes && can.DeleteFlag == ActiveDelete.No

                                        select new CANDIDATEEXT
                                        {
                                            CANDIDATEID = can.CANDIDATEID,
                                            CANDIDATEFULLNAME = can.CANDIDATEFULLNAME,
                                            CANDIDATECD = can.CANDIDATECD,
                                            CANDIDATECT = can.CANDIDATECT,
                                            CANDIDATEUT = can.CANDIDATEUT,
                                            CANDIDATEUD = can.CANDIDATEUD,
                                            CANDIDATEEMAIL = can.CANDIDATEEMAIL,
                                            CANDIDATEPHONE = can.CANDIDATEPHONE,
                                            CANDIDATELOCCOUNTRY = can.CANDIDATELOCCOUNTRY,
                                            CANDIDATELOCSTATE = can.CANDIDATELOCSTATE,
                                            CANDIDATELOCCITY = can.CANDIDATELOCCITY,
                                            CANDIDATEADDRESS = can.CANDIDATEADDRESS,
                                            CANDIDATEGENDER = can.CANDIDATEGENDER,
                                            CANDIDATETAXTERM = can.CANDIDATETAXTERM,
                                            CANDIDATEEMPLOYER = can.CANDIDATEEMPLOYER,
                                            VISADATEOFISSUE = can.VISADATEOFISSUE,
                                            VISAVAILDUPTO = can.VISAVAILDUPTO,
                                            CANDIDATEGENDERNAME = gnd.GENDERNAME,
                                            CANDIDATELOCCOUNTRYNAME = cnty.COUNTRYNAME,
                                            CANDIDATELOCSTATENAME = sta.STATENAME,
                                            CANDIDATELOCCITYNAME = cty.CITYNAME,
                                            CANDIDATETAXTERMNAME = tt.TAXTERMNAME,
                                            CANDIDATEEMPLOYERNAME = emp.EMPLOYERNAME
                                        }).OrderByDescending(x=>x.CANDIDATEID).ToListAsync();
                return candidates;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<List<CANDIDATEEXT>> GetCANDIDATESBYNAME(KeyValue kv)
        {
            try
            {
                var candidates = await (from can in _dbContext.CANDIDATES
                                       join gnd in _dbContext.GENDERS on can.CANDIDATEGENDER equals gnd.GENDERID
                                       join cnty in _dbContext.COUNTRIES on can.CANDIDATELOCCOUNTRY equals cnty.COUNTRYID
                                       join sta in _dbContext.STATES on can.CANDIDATELOCSTATE equals sta.STATEID
                                       join cty in _dbContext.CITIES on can.CANDIDATELOCCITY equals cty.CITYID
                                       join tt in _dbContext.TAXTERMES on can.CANDIDATETAXTERM equals tt.TAXTERMID
                                       join emp in _dbContext.EMPLOYERS on can.CANDIDATEEMPLOYER equals emp.EMPLOYERID

                                       where can.CANDIDATEFULLNAME.Contains(kv.VALUE1) && can.ActiveFlag == ActiveDelete.Yes && can.DeleteFlag == ActiveDelete.No

                                       select new CANDIDATEEXT
                                       {
                                           CANDIDATEID = can.CANDIDATEID,
                                           CANDIDATEFULLNAME = can.CANDIDATEFULLNAME,
                                           CANDIDATECD = can.CANDIDATECD,
                                           CANDIDATECT = can.CANDIDATECT,
                                           CANDIDATEUT = can.CANDIDATEUT,
                                           CANDIDATEUD = can.CANDIDATEUD,
                                           CANDIDATEEMAIL = can.CANDIDATEEMAIL,
                                           CANDIDATEPHONE = can.CANDIDATEPHONE,
                                           CANDIDATELOCCOUNTRY = can.CANDIDATELOCCOUNTRY,
                                           CANDIDATELOCSTATE = can.CANDIDATELOCSTATE,
                                           CANDIDATELOCCITY = can.CANDIDATELOCCITY,
                                           CANDIDATEADDRESS = can.CANDIDATEADDRESS,
                                           CANDIDATEGENDER = can.CANDIDATEGENDER,
                                           CANDIDATETAXTERM = can.CANDIDATETAXTERM,
                                           CANDIDATEEMPLOYER = can.CANDIDATEEMPLOYER,
                                           VISADATEOFISSUE = can.VISADATEOFISSUE,
                                           VISAVAILDUPTO = can.VISAVAILDUPTO,
                                           CANDIDATEGENDERNAME = gnd.GENDERNAME,
                                           CANDIDATELOCCOUNTRYNAME = cnty.COUNTRYNAME,
                                           CANDIDATELOCSTATENAME = sta.STATENAME,
                                           CANDIDATELOCCITYNAME = cty.CITYNAME,
                                           CANDIDATETAXTERMNAME = tt.TAXTERMNAME,
                                           CANDIDATEEMPLOYERNAME = emp.EMPLOYERNAME
                                       }).OrderBy(x=>x.CANDIDATEFULLNAME).ToListAsync();
                return candidates;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<bool> UpdateCANDIDATE(CANDIDATE candidate)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = candidate.CANDIDATEID;
            try
            {
                var can = await GetById(kv);
                if(can != null)
                {
                    candidate.CANDIDATEUD = DateTime.Now;
                    candidate.CANDIDATEUT = DateTime.Now.TimeOfDay;
                    _dbContext.Entry<CANDIDATE>(candidate).State = EntityState.Modified;
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else { return false; }
            }
            catch(Exception ex) { return false; }
        }

        private async Task<CANDIDATEEXT> GetById(KeyValue kv)
        {
            try
            {
                var candidate = await (from can in _dbContext.CANDIDATES
                                       join gnd in _dbContext.GENDERS on can.CANDIDATEGENDER equals gnd.GENDERID
                                       join cnty in _dbContext.COUNTRIES on can.CANDIDATELOCCOUNTRY equals cnty.COUNTRYID
                                       join sta in _dbContext.STATES on can.CANDIDATELOCSTATE equals sta.STATEID
                                       join cty in _dbContext.CITIES on can.CANDIDATELOCCITY equals cty.CITYID
                                       join tt in _dbContext.TAXTERMES on can.CANDIDATETAXTERM equals tt.TAXTERMID
                                       join emp in _dbContext.EMPLOYERS on can.CANDIDATEEMPLOYER equals emp.EMPLOYERID

                                       where can.CANDIDATEID == kv.KEY1 && can.ActiveFlag == ActiveDelete.Yes && can.DeleteFlag == ActiveDelete.No

                                       select new CANDIDATEEXT
                                       {
                                           CANDIDATEID = can.CANDIDATEID,
                                           CANDIDATEFULLNAME = can.CANDIDATEFULLNAME,
                                           CANDIDATECD = can.CANDIDATECD,
                                           CANDIDATECT = can.CANDIDATECT,
                                           CANDIDATEUT = can.CANDIDATEUT,
                                           CANDIDATEUD = can.CANDIDATEUD,
                                           CANDIDATEEMAIL = can.CANDIDATEEMAIL,
                                           CANDIDATEPHONE = can.CANDIDATEPHONE,
                                           CANDIDATELOCCOUNTRY = can.CANDIDATELOCCOUNTRY,
                                           CANDIDATELOCSTATE = can.CANDIDATELOCSTATE,
                                           CANDIDATELOCCITY = can.CANDIDATELOCCITY,
                                           CANDIDATEADDRESS = can.CANDIDATEADDRESS,
                                           CANDIDATEGENDER = can.CANDIDATEGENDER,
                                           CANDIDATETAXTERM = can.CANDIDATETAXTERM,
                                           CANDIDATEEMPLOYER = can.CANDIDATEEMPLOYER,
                                           VISADATEOFISSUE = can.VISADATEOFISSUE,
                                           VISAVAILDUPTO = can.VISAVAILDUPTO,
                                           CANDIDATEGENDERNAME = gnd.GENDERNAME,
                                           CANDIDATELOCCOUNTRYNAME = cnty.COUNTRYNAME,
                                           CANDIDATELOCSTATENAME = sta.STATENAME,
                                           CANDIDATELOCCITYNAME = cty.CITYNAME,
                                           CANDIDATETAXTERMNAME = tt.TAXTERMNAME,
                                           CANDIDATEEMPLOYERNAME = emp.EMPLOYERNAME
                                       }).FirstOrDefaultAsync();
                return candidate;
            }
            catch (Exception ex) { return null; }
        }
    }
}
