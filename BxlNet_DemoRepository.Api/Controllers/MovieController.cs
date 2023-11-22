using BxlNet_DemoRepository.Api.Models.Dtos;
using BxlNet_DemoRepository.Models.Commands;
using BxlNet_DemoRepository.Models.Entities;
using BxlNet_DemoRepository.Models.Queries;
using BxlNet_DemoRepository.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Tools.CQS;

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
            IQueryResult<IEnumerable<Movie>> result = _repository.Execute(new GetAllMovieQuery());

            if(result.IsFailure)
               return BadRequest(result.ErrorMessage);

            return Ok(result.Result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IQueryResult<Movie> result = _repository.Execute(new GetMovieByIdQuery(id));

            if (result.IsFailure)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateMovieDto dto) 
        {
            ICommandResult result = _repository.Execute(new AddMovieCommand(dto.Title, dto.Year, dto.Realisator));
            
            if(result.IsFailure)
                return BadRequest(result.ErrorMessage);

            return NoContent();
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] UpdateMovieDto dto)
        //{
        //    _repository.Update(new Movie() { Id = id, Title = dto.Title, Year = dto.Year, Realisator = dto.Realisator });
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ICommandResult result = _repository.Execute(new DeleteMovieCommand(id));

            if (result.IsFailure)
                return BadRequest(result.ErrorMessage);

            return NoContent();
        }
    }
}
