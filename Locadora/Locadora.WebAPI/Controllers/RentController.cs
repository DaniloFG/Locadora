using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _service;

        public RentController(IRentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentDTO>>> Get()
        {
            var rents = await _service.GetAllAsync();

            if (rents == null)
                return NotFound("Rents not found");

            return Ok(rents);
        }

        [HttpGet("{id:int}", Name = "GetRent")]
        public async Task<ActionResult<RentDTO>> Get(int id)
        {
            var rent = await _service.GetByIdAsync(id);

            if (rent == null)
                return NotFound("Rent not found");

            return Ok(rent);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RentDTO RentDTO)
        {
            if (RentDTO == null)
                return BadRequest("Invalid Data");

            await _service.CreateAsync(RentDTO);

            return new CreatedAtRouteResult("GetRent", new { id = RentDTO.Id }, RentDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] RentDTO RentDTO)
        {
            if (id != RentDTO.Id)
                return BadRequest();

            if (RentDTO == null)
                return BadRequest();

            await _service.UpdateAsync(RentDTO);

            return Ok(RentDTO);
        }
    }
}
