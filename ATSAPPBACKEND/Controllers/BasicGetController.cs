using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ATSAPPBACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicGetController : ControllerBase
    {
        private readonly IBASICGETS _BASICGETS;

        public BasicGetController(IBASICGETS bASICGETS)
        {
            _BASICGETS = bASICGETS;
        }

        [HttpPost("GetGENDERS")]
        public async Task<List<GENDER>> GetGENDERS()
        {
            var genders = await _BASICGETS.GetGENDER();
            return genders;
        }

        [HttpPost("GetCOUNTRIES")]
        public async Task<List<COUNTRY>> GetCOUNTRIES()
        {
            var countries = await _BASICGETS.GetCOUNTRIES();
            return countries;
        }

        [HttpPost("GetSTATESBYCOUNTRY")]
        public async Task<List<STATE>> GetSTATESBYCOUNTRY([FromBody] KeyValue kv)
        {
            var states = await _BASICGETS.GetSTATES(kv);
            return states;
        }

        [HttpPost("GetCITIESBYSTATE")]
        public async Task<List<CITY>> GetCITIESBYSTATE([FromBody] KeyValue kv)
        {
            var cities = await _BASICGETS.GetCITIES(kv);
            return cities;
        }

        [HttpPost("GetHYBRIDTYPES")]
        public async Task<List<HYBRIDTYPE>> GetHYBRIDTYPES()
        {
            var hybridtypes = await _BASICGETS.GetHYBRIDTYPES();
            return hybridtypes;
        }

        [HttpPost("GetSUBMISSIONSTATUSES")]
        public async Task<List<SUBMISSIONSTATUS>> GetSUBMISSIONSTATUSES()
        {
            var submissionStatus = await _BASICGETS.GetSUBMISSIONSTATUSES();
            return submissionStatus;
        }

        [HttpPost("GetTAXTERMS")]
        public async Task<List<TAXTERM>> GetTAXTERMS()
        {
            var taxterms = await _BASICGETS.GetTAXTERMS();
            return taxterms;
        }

        [HttpPost("GetVISAS")]
        public async Task<List<VISA>> GetVISAS()
        {
            var visas = await _BASICGETS.GetVISAS();
            return visas;
        }

        [HttpPost("GetWORKNATURES")]
        public async Task<List<WORKNATURE>> GetWORKNATURES()
        {
            var wn = await _BASICGETS.GetWORKNATURES();
            return wn;
        }
    }
}
