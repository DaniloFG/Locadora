using AutoMapper;
using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.Services
{
    public class FilmService : IFilmService
    {
        private IFilmRepository _repository;
        private readonly IMapper _mapper;

        public FilmService(IFilmRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(FilmDTO FilmDTO)
        {
            var filmEntity = _mapper.Map<Film>(FilmDTO);
            await _repository.CreateAsync(filmEntity);
        }

        public async Task<IEnumerable<FilmDTO>> GetAllAsync()
        {
            var filmEntity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<FilmDTO>>(filmEntity);
        }

        public async Task<FilmDTO> GetByIdAsync(int id)
        {
            var filmEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<FilmDTO>(filmEntity);
        }

        public async Task UpdateAsync(FilmDTO FilmDTO)
        {
            var filmEntity = _mapper.Map<Film>(FilmDTO);
            await _repository.UpdateAsync(filmEntity);
        }
    }
}
