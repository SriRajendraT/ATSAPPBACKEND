using ATSAPPBACKEND.DAL;
using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATSAPPBACKEND.Repositories.Classes
{
    public class SUBMISSIONREPOSITORY : ISUBMISSIONREPOSITORY
    {
        private readonly AppDbContext _dbContext;

        public SUBMISSIONREPOSITORY(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ADDSUBMISSION(SUBMISSION submission)
        {
            try
            {
                if (submission != null)
                {
                    submission.ActiveFlag = ActiveDelete.Yes;
                    submission.DeleteFlag = ActiveDelete.No;
                    submission.SUBMISSIONCD = DateTime.Now;
                    submission.SUBMISSIONCT = DateTime.Now.TimeOfDay;
                    await _dbContext.SUBMISSIONS.AddAsync(submission);
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else { return false; }
            }
            catch (Exception ex) { return false; }
        }

        public async Task<bool> DELETESUBMISSION(SUBMISSION submission)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = submission.SUBMISSIONID;
            try
            {
                var sub = await GetById(kv);
                if (sub != null)
                {
                    submission.ActiveFlag = ActiveDelete.No;
                    submission.DeleteFlag = ActiveDelete.Yes;
                    _dbContext.Entry<SUBMISSION>(submission).State = EntityState.Modified;
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else { return false; }
            }
            catch (Exception e) { return false; }
        }

        public async Task<SUBMISSIONEXT> GETSUBMISSIONBYID(KeyValue kv)
        {
            var submission = await GetById(kv);
            return submission;
        }

        public async Task<List<SUBMISSIONEXT>> GETSUBMISSIONBYNAME(KeyValue kv)
        {
            try
            {
                var submissions = await (from subs in _dbContext.SUBMISSIONS
                                         join req in _dbContext.REQUIREMENTS on subs.REQUIREMENTID equals req.REQUIREMENTID
                                         join cand in _dbContext.CANDIDATES on subs.CANDIDATEID equals cand.CANDIDATEID
                                         join sus in _dbContext.SUBMISSIONSTATUSES on subs.SUBMISSIONSTATUSID equals sus.SUBMISSIONSTATUSID

                                         where cand.CANDIDATEFULLNAME.Contains(kv.VALUE1) || req.REQUIREMENTTITLE.Contains(kv.VALUE1)
                                         && subs.ActiveFlag == ActiveDelete.Yes && subs.DeleteFlag == ActiveDelete.No

                                         select new SUBMISSIONEXT
                                         {
                                             SUBMISSIONID = subs.SUBMISSIONID,
                                             REQUIREMENTID = subs.REQUIREMENTID,
                                             CANDIDATEID = subs.CANDIDATEID,
                                             SUBMISSIONSTATUSID = subs.SUBMISSIONSTATUSID,
                                             SUBMISSIONCD = subs.SUBMISSIONCD,
                                             SUBMISSIONCT = subs.SUBMISSIONCT,
                                             SUBMISSIONUD = subs.SUBMISSIONUD,
                                             SUBMISSIONUT = subs.SUBMISSIONUT,
                                             ActiveFlag = subs.ActiveFlag,
                                             DeleteFlag = subs.DeleteFlag,
                                             REQUIREMENTNAME = req.REQUIREMENTTITLE,
                                             CANDIDATENAME = cand.CANDIDATEFULLNAME,
                                             SUBMISSIONSTATUSNAME = sus.SUBMISSIONSTATUSNAME
                                         }).ToListAsync();
                return submissions;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<List<SUBMISSIONEXT>> GETSUBMISSIONS()
        {
            try
            {
                var submissions = await (from subs in _dbContext.SUBMISSIONS
                                         join req in _dbContext.REQUIREMENTS on subs.REQUIREMENTID equals req.REQUIREMENTID
                                         join cand in _dbContext.CANDIDATES on subs.CANDIDATEID equals cand.CANDIDATEID
                                         join sus in _dbContext.SUBMISSIONSTATUSES on subs.SUBMISSIONSTATUSID equals sus.SUBMISSIONSTATUSID

                                         where subs.ActiveFlag == ActiveDelete.Yes && subs.DeleteFlag == ActiveDelete.No

                                         select new SUBMISSIONEXT
                                         {
                                             SUBMISSIONID = subs.SUBMISSIONID,
                                             REQUIREMENTID = subs.REQUIREMENTID,
                                             CANDIDATEID = subs.CANDIDATEID,
                                             SUBMISSIONSTATUSID = subs.SUBMISSIONSTATUSID,
                                             SUBMISSIONCD = subs.SUBMISSIONCD,
                                             SUBMISSIONCT = subs.SUBMISSIONCT,
                                             SUBMISSIONUD = subs.SUBMISSIONUD,
                                             SUBMISSIONUT = subs.SUBMISSIONUT,
                                             ActiveFlag = subs.ActiveFlag,
                                             DeleteFlag = subs.DeleteFlag,
                                             REQUIREMENTNAME = req.REQUIREMENTTITLE,
                                             CANDIDATENAME = cand.CANDIDATEFULLNAME,
                                             SUBMISSIONSTATUSNAME = sus.SUBMISSIONSTATUSNAME
                                         }).ToListAsync();
                return submissions;
            }
            catch (Exception e) { return null; }
        }

        public async Task<bool> UPDATESUBMISSION(SUBMISSION submission)
        {
            KeyValue kv = new KeyValue();
            kv.KEY1 = submission.SUBMISSIONID;
            try
            {
                var sub = await GetById(kv);
                if (sub != null)
                {
                    submission.SUBMISSIONUD = DateTime.Now;
                    submission.SUBMISSIONCT = DateTime.Now.TimeOfDay;
                    _dbContext.Entry<SUBMISSION>(submission).State = EntityState.Modified;
                    return await _dbContext.SaveChangesAsync() > 0;
                }else { return  false; }
            }catch (Exception e) { return false; }
        }

        private async Task<SUBMISSIONEXT> GetById(KeyValue kv)
        {
            try
            {
                var submission = await (from subs in _dbContext.SUBMISSIONS
                                        join req in _dbContext.REQUIREMENTS on subs.REQUIREMENTID equals req.REQUIREMENTID
                                        join cand in _dbContext.CANDIDATES on subs.CANDIDATEID equals cand.CANDIDATEID
                                        join sus in _dbContext.SUBMISSIONSTATUSES on subs.SUBMISSIONSTATUSID equals sus.SUBMISSIONSTATUSID

                                        where subs.SUBMISSIONID == kv.KEY1 && subs.ActiveFlag == ActiveDelete.Yes && subs.DeleteFlag == ActiveDelete.No

                                        select new SUBMISSIONEXT
                                        {
                                            SUBMISSIONID = subs.SUBMISSIONID,
                                            REQUIREMENTID = subs.REQUIREMENTID,
                                            CANDIDATEID = subs.CANDIDATEID,
                                            SUBMISSIONSTATUSID = subs.SUBMISSIONSTATUSID,
                                            SUBMISSIONCD = subs.SUBMISSIONCD,
                                            SUBMISSIONCT = subs.SUBMISSIONCT,
                                            SUBMISSIONUD = subs.SUBMISSIONUD,
                                            SUBMISSIONUT = subs.SUBMISSIONUT,
                                            ActiveFlag = subs.ActiveFlag,
                                            DeleteFlag = subs.DeleteFlag,
                                            REQUIREMENTNAME = req.REQUIREMENTTITLE,
                                            CANDIDATENAME = cand.CANDIDATEFULLNAME,
                                            SUBMISSIONSTATUSNAME = sus.SUBMISSIONSTATUSNAME
                                        }).FirstOrDefaultAsync();
                return submission;
            }
            catch (Exception e) { return null; }
        }
    }
}
