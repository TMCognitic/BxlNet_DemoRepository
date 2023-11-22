using BxlNet_DemoRepository.Api.Models.Dtos;
using BxlNet_DemoRepository.Models.Entities;
using BxlNet_DemoRepository.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BxlNet_DemoRepository.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieRepository _repository;

        public MovieController(ILogger<MovieController> logger, IMovieRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateMovieDto dto) 
        {
            _repository.Insert(new Movie() { Title = dto.Title, Year = dto.Year, Realisator = dto.Realisator });
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateMovieDto dto)
        {
            _repository.Update(new Movie() { Id = id, Title = dto.Title, Year = dto.Year, Realisator = dto.Realisator });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
