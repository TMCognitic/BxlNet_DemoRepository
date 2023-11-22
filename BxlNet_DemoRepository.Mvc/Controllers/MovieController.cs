using BxlNet_DemoRepository.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BxlNet_DemoRepository.Mvc.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _repository;

        public MovieController(IMovieRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }
    }
}
