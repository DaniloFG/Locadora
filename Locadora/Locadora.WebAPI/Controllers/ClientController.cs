using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> Get()
        {
            var clients = await _service.GetAllAsync();

            if (clients == null)
                return NotFound("Clients not found");

            return Ok(clients);
        }

        [HttpGet("{id:int}", Name = "GetClient")]
        public async Task<ActionResult<ClientDTO>> Get(int id)
        {
            var client = await _service.GetByIdAsync(id);

            if (client == null)
                return NotFound("Client not found");

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientDTO ClientDTO)
        {
            if (ClientDTO == null)
                return BadRequest("Invalid Data");

            await _service.CreateAsync(ClientDTO);

            return new CreatedAtRouteResult("GetClient", new { id = ClientDTO.Id }, ClientDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ClientDTO ClientDTO)
        {
            if (id != ClientDTO.Id)
                return BadRequest();

            if (ClientDTO == null)
                return BadRequest();

            await _service.UpdateAsync(ClientDTO);

            return Ok(ClientDTO);
        }
    }
}
