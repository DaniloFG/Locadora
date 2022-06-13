using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _service;

        public FilmController(IFilmService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmDTO>>> Get()
        {
            var films = await _service.GetAllAsync();

            if (films == null)
                return NotFound("Films not found");

            return Ok(films);
        }

        [HttpGet("{id:int}", Name = "GetFilm")]
        public async Task<ActionResult<FilmDTO>> Get(int id)
        {
            var film = await _service.GetByIdAsync(id);

            if (film == null)
                return NotFound("Film not found");

            return Ok(film);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FilmDTO FilmDTO)
        {
            if (FilmDTO == null)
                return BadRequest("Invalid Data");

            await _service.CreateAsync(FilmDTO);

            return new CreatedAtRouteResult("GetFilm", new { id = FilmDTO.Id }, FilmDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] FilmDTO FilmDTO)
        {
            if (id != FilmDTO.Id)
                return BadRequest();

            if (FilmDTO == null)
                return BadRequest();

            await _service.UpdateAsync(FilmDTO);

            return Ok(FilmDTO);
        }
    }
}
