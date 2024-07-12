using ATSAPPBACKEND.DAL;
using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATSAPPBACKEND.Repositories.Classes
{
    public class REQUIREMENTREPOSITORY : IREQUIREMENTREPOSITORY
    {
        private readonly AppDbContext _dbContext;

        public REQUIREMENTREPOSITORY(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddREQUIREMENT(ReqVisa requirement)
        {
            try
            {
                if (requirement != null)
                {
                    requirement.req.REQUIREMENTCD = DateTime.Now;
                    requirement.req.REQUIREMENTCT = DateTime.Now.TimeOfDay;
                    requirement.req.ActiveFlag = ActiveDelete.Yes;
                    requirement.req.DeleteFlag = ActiveDelete.No;
                    await _dbContext.REQUIREMENTS.AddAsync(requirement.req);
                    await _dbContext.SaveChangesAsync();

                    var reqid = requirement.req.REQUIREMENTID;
                    var rv = new REQUIREDVISA();
                    foreach (var item in requirement.visas)
                    {
                        rv.REQUIREMENTID = reqid;
                        rv.VISAID = item.VISAID;
                        await _dbContext.REQUIREDVISAS.AddAsync(rv);
                    }
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteREQUIREMENT(ReqVisa requirement)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = requirement.req.REQUIREMENTID;
            try
            {
                var emp = await GetById(kv);
                if (emp != null)
                {
                    requirement.req.REQUIREMENTUD = DateTime.Now;
                    requirement.req.REQUIREMENTUT = DateTime.Now.TimeOfDay;
                    requirement.req.ActiveFlag = ActiveDelete.No;
                    requirement.req.DeleteFlag = ActiveDelete.Yes;
                    _dbContext.Entry<REQUIREMENT>(requirement.req).State = EntityState.Modified;
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else { return false; }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<REQUIREMENTEXT> GetREQUIREMENTBYID(KeyValue kv)
        {
            var req = await GetById(kv);
            return req;
        }

        public async Task<List<REQUIREMENTEXT>> GetREQUIREMENTBYNAME(KeyValue kv)
        {
            try
            {
                var reqs = await (from req in _dbContext.REQUIREMENTS
                                  join wn in _dbContext.WORKNATURES on req.REQUIREMENTWN equals wn.WORKNATUREID
                                  join hbt in _dbContext.HYBRIDTYPES on req.REQUIREMENTHYBRIDTYPE equals hbt.HYBRIDTYPEID
                                  join imp in _dbContext.IMPLEMENTATIONS on req.REQUIREMENTIMPLEMENTATION equals imp.IMPLEMENTATIONID
                                  join cli in _dbContext.CLIENTS on req.REQUIREMENTCLIENT equals cli.CLIENTID
                                  join cnty in _dbContext.COUNTRIES on req.REQUIREMENTLOCCOUNTRY equals cnty.COUNTRYID
                                  join sta in _dbContext.STATES on req.REQUIREMENTLOCSTATE equals sta.STATEID
                                  join cty in _dbContext.CITIES on req.REQUIREMENTLOCCITY equals cty.CITYID

                                  where req.REQUIREMENTTITLE.Contains(kv.VALUE1) && req.ActiveFlag == ActiveDelete.Yes && req.DeleteFlag == ActiveDelete.No

                                  select new REQUIREMENTEXT
                                  {
                                      REQUIREMENTID = req.REQUIREMENTID,
                                      REQUIREMENTTITLE = req.REQUIREMENTTITLE,
                                      REQUIREMENTDESC = req.REQUIREMENTDESC,
                                      REQUIREMENTCD = req.REQUIREMENTCD,
                                      REQUIREMENTCT = req.REQUIREMENTCT,
                                      REQUIREMENTUD = req.REQUIREMENTUD,
                                      REQUIREMENTUT = req.REQUIREMENTUT,
                                      REQUIREMENTMAXRATE = req.REQUIREMENTMAXRATE,
                                      REQUIREMENTLOCCOUNTRY = req.REQUIREMENTLOCCOUNTRY,
                                      REQUIREMENTLOCSTATE = req.REQUIREMENTLOCSTATE,
                                      REQUIREMENTLOCCITY = req.REQUIREMENTLOCCITY,
                                      REQUIREMENTHYBRIDTYPE = req.REQUIREMENTHYBRIDTYPE,
                                      REQUIREMENTWN = req.REQUIREMENTWN,
                                      REQUIREMENTCLIENT = req.REQUIREMENTCLIENT,
                                      REQUIREMENTIMPLEMENTATION = req.REQUIREMENTIMPLEMENTATION,
                                      REQUIREMENTLOCCITYNAME = cty.CITYNAME,
                                      REQUIREMENTLOCSTATENAME = sta.STATENAME,
                                      REQUIREMENTLOCCOUNTRYNAME = cnty.COUNTRYNAME,
                                      REQUIREMENTWNNANME = wn.WORKNATURENAME,
                                      REQUIREMENTHYBRIDTYPENAME = hbt.HYBRIDTYPENAME,
                                      REQUIREMENTIMPLEMENTATIONNAME = imp.IMPLEMENTATIONNAME,
                                      REQUIREMENTCLIENTNAME = cli.CLIENTNAME
                                  }).ToListAsync();
                return reqs;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<List<REQUIREMENTEXT>> GetREQUIREMENTS()
        {
            try
            {
                var reqs = await (from req in _dbContext.REQUIREMENTS
                                  join wn in _dbContext.WORKNATURES on req.REQUIREMENTWN equals wn.WORKNATUREID
                                  join hbt in _dbContext.HYBRIDTYPES on req.REQUIREMENTHYBRIDTYPE equals hbt.HYBRIDTYPEID
                                  join imp in _dbContext.IMPLEMENTATIONS on req.REQUIREMENTIMPLEMENTATION equals imp.IMPLEMENTATIONID
                                  join cli in _dbContext.CLIENTS on req.REQUIREMENTCLIENT equals cli.CLIENTID
                                  join cnty in _dbContext.COUNTRIES on req.REQUIREMENTLOCCOUNTRY equals cnty.COUNTRYID
                                  join sta in _dbContext.STATES on req.REQUIREMENTLOCSTATE equals sta.STATEID
                                  join cty in _dbContext.CITIES on req.REQUIREMENTLOCCITY equals cty.CITYID

                                  where req.ActiveFlag == ActiveDelete.Yes && req.DeleteFlag == ActiveDelete.No

                                  select new REQUIREMENTEXT
                                  {
                                      REQUIREMENTID = req.REQUIREMENTID,
                                      REQUIREMENTTITLE = req.REQUIREMENTTITLE,
                                      REQUIREMENTDESC = req.REQUIREMENTDESC,
                                      REQUIREMENTCD = req.REQUIREMENTCD,
                                      REQUIREMENTCT = req.REQUIREMENTCT,
                                      REQUIREMENTUD = req.REQUIREMENTUD,
                                      REQUIREMENTUT = req.REQUIREMENTUT,
                                      REQUIREMENTMAXRATE = req.REQUIREMENTMAXRATE,
                                      REQUIREMENTLOCCOUNTRY = req.REQUIREMENTLOCCOUNTRY,
                                      REQUIREMENTLOCSTATE = req.REQUIREMENTLOCSTATE,
                                      REQUIREMENTLOCCITY = req.REQUIREMENTLOCCITY,
                                      REQUIREMENTHYBRIDTYPE = req.REQUIREMENTHYBRIDTYPE,
                                      REQUIREMENTWN = req.REQUIREMENTWN,
                                      REQUIREMENTCLIENT = req.REQUIREMENTCLIENT,
                                      REQUIREMENTIMPLEMENTATION = req.REQUIREMENTIMPLEMENTATION,
                                      REQUIREMENTLOCCITYNAME = cty.CITYNAME,
                                      REQUIREMENTLOCSTATENAME = sta.STATENAME,
                                      REQUIREMENTLOCCOUNTRYNAME = cnty.COUNTRYNAME,
                                      REQUIREMENTWNNANME = wn.WORKNATURENAME,
                                      REQUIREMENTHYBRIDTYPENAME = hbt.HYBRIDTYPENAME,
                                      REQUIREMENTIMPLEMENTATIONNAME = imp.IMPLEMENTATIONNAME,
                                      REQUIREMENTCLIENTNAME = cli.CLIENTNAME
                                  }).ToListAsync();
                return reqs;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<bool> UpdateREQUIREMENT(ReqVisa requirement)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = requirement.req.REQUIREMENTID;
            try
            {
                var emp = await GetById(kv);
                if (emp != null)
                {
                    requirement.req.REQUIREMENTUD = DateTime.Now;
                    requirement.req.REQUIREMENTUT = DateTime.Now.TimeOfDay;
                    _dbContext.Entry<REQUIREMENT>(requirement.req).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();

                    var reqid = requirement.req.REQUIREMENTID;
                    var sv = requirement.visas;
                    var rv = await _dbContext.REQUIREDVISAS.Where(x => x.REQUIREMENTID == reqid).ToListAsync();

                    var notmatchedfromold = rv.Where(x => !(sv.Select(y => y.VISAID).Contains(x.VISAID))).ToList();
                    var notmatchNew = sv.Where(x => !(rv.Select(y => y.VISAID).Contains(x.VISAID))).ToList();
                    foreach (var item in notmatchedfromold)
                    {
                        _dbContext.REQUIREDVISAS.Remove(item);
                    }
                    foreach (var item in notmatchNew)
                    {
                        var reqV = new REQUIREDVISA();
                        reqV.REQUIREMENTID = reqid;
                        reqV.VISAID = item.VISAID;
                        await _dbContext.REQUIREDVISAS.AddAsync(reqV);
                    }

                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else { return false; }
            }
            catch (Exception ex) { return false; }
        }

        private async Task<REQUIREMENTEXT> GetById(KeyValue kv)
        {
            try
            {
                var reqs = await (from req in _dbContext.REQUIREMENTS
                                  join wn in _dbContext.WORKNATURES on req.REQUIREMENTWN equals wn.WORKNATUREID
                                  join hbt in _dbContext.HYBRIDTYPES on req.REQUIREMENTHYBRIDTYPE equals hbt.HYBRIDTYPEID
                                  join imp in _dbContext.IMPLEMENTATIONS on req.REQUIREMENTIMPLEMENTATION equals imp.IMPLEMENTATIONID
                                  join cli in _dbContext.CLIENTS on req.REQUIREMENTCLIENT equals cli.CLIENTID
                                  join cnty in _dbContext.COUNTRIES on req.REQUIREMENTLOCCOUNTRY equals cnty.COUNTRYID
                                  join sta in _dbContext.STATES on req.REQUIREMENTLOCSTATE equals sta.STATEID
                                  join cty in _dbContext.CITIES on req.REQUIREMENTLOCCITY equals cty.CITYID

                                  where req.REQUIREMENTID == kv.KEY1 && req.ActiveFlag == ActiveDelete.Yes && req.DeleteFlag == ActiveDelete.No

                                  select new REQUIREMENTEXT
                                  {
                                      REQUIREMENTID = req.REQUIREMENTID,
                                      REQUIREMENTTITLE = req.REQUIREMENTTITLE,
                                      REQUIREMENTDESC = req.REQUIREMENTDESC,
                                      REQUIREMENTCD = req.REQUIREMENTCD,
                                      REQUIREMENTCT = req.REQUIREMENTCT,
                                      REQUIREMENTUD = req.REQUIREMENTUD,
                                      REQUIREMENTUT = req.REQUIREMENTUT,
                                      REQUIREMENTMAXRATE = req.REQUIREMENTMAXRATE,
                                      REQUIREMENTLOCCOUNTRY = req.REQUIREMENTLOCCOUNTRY,
                                      REQUIREMENTLOCSTATE = req.REQUIREMENTLOCSTATE,
                                      REQUIREMENTLOCCITY = req.REQUIREMENTLOCCITY,
                                      REQUIREMENTHYBRIDTYPE = req.REQUIREMENTHYBRIDTYPE,
                                      REQUIREMENTWN = req.REQUIREMENTWN,
                                      REQUIREMENTCLIENT = req.REQUIREMENTCLIENT,
                                      REQUIREMENTIMPLEMENTATION = req.REQUIREMENTIMPLEMENTATION,
                                      REQUIREMENTLOCCITYNAME = cty.CITYNAME,
                                      REQUIREMENTLOCSTATENAME = sta.STATENAME,
                                      REQUIREMENTLOCCOUNTRYNAME = cnty.COUNTRYNAME,
                                      REQUIREMENTWNNANME = wn.WORKNATURENAME,
                                      REQUIREMENTHYBRIDTYPENAME = hbt.HYBRIDTYPENAME,
                                      REQUIREMENTIMPLEMENTATIONNAME = imp.IMPLEMENTATIONNAME,
                                      REQUIREMENTCLIENTNAME = cli.CLIENTNAME
                                  }).FirstOrDefaultAsync();
                return reqs;
            }
            catch (Exception ex) { return null; }
        }
    }
}
