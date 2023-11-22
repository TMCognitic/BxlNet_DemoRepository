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
    }
}
