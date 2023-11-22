using BxlNet_DemoRepository.Models.Entities;
using BxlNet_DemoRepository.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Repositories;

namespace BxlNet_DemoRepository.Models.Services
{
    public class FakeMovieService : IMovieRepository
    {
        private readonly IList<Movie> _items;

        public FakeMovieService()
        {
            _items = new List<Movie>()
            {
                new Movie() { Id = 1, Title = "P'tie annick", Year = 1998, Realisator = "James Cameron"},
                new Movie() { Id = 2, Title = "Le silence des anneaux", Year = 1991, Realisator = "Jonathan Demme" },
                new Movie() { Id = 3, Title = "Le seigneur des agneaux", Year = 2001, Realisator = "Peter Jackson" }
            };
        }

        public IEnumerable<Movie> GetAll()
        {
            return _items;
        }

        public Movie? GetById(int id)
        {
            return _items.SingleOrDefault(m => m.Id == id);
        }

        public void Insert(Movie entity)
        {
            entity.Id = _items.Count == 0 ? 1 : _items.Max(m => m.Id) + 1;
            _items.Add(entity);
        }

        public void Update(Movie entity)
        {
        }

        public void Delete(int id)
        {
            Movie? movie = _items.SingleOrDefault(m => m.Id == id);
            if (movie is not null)
            {
                _items.Remove(movie);
            }
        }
    }
}
