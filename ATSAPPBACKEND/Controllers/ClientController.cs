using ATSAPPBACKEND.Models;
using ATSAPPBACKEND.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATSAPPBACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ICLIENTREPOSITORY _clientRepository;

        public ClientController(ICLIENTREPOSITORY clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpPost("GetAllClients")]
        public async Task<List<CLIENT>> GetAllClients()
        {
            var clients = await _clientRepository.GetCLIENTS();
            return clients;
        }

        [HttpPost("GetClientById")]
        public async Task<CLIENT> GetClientById([FromBody] KeyValue kv)
        {
            var client = await _clientRepository.GetCLIENTSBYID(kv);
            return client;
        }

        [HttpPost("GetClientsByName")]
        public async Task<List<CLIENT>> GetClientsByName([FromBody] KeyValue kv)
        {
            var clients = await _clientRepository.GetCLIENTSBYNAME(kv);
            return clients;
        }

        [HttpPost("AddOrUpdateClient")]
        public async Task<bool> AddOrUpdateClient([FromBody] CLIENT client)
        {
            if (ModelState.IsValid)
            {
                if (client.CLIENTID != 0)
                {
                    return await _clientRepository.UpdateCLIENT(client);
                }
                else
                {
                    return await _clientRepository.AddCLIENT(client);
                }
            }
            else { return false; }
        }

        [HttpPost("DeleteClient")]
        public async Task<bool> DeleteClient([FromBody] CLIENT client)
        {
            return await _clientRepository.DeleteCLIENT(client);
        }
    }
}
