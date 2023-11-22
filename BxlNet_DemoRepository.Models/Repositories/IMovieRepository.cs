using BxlNet_DemoRepository.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BxlNet_DemoRepository.Models.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie? GetById(int id);
        void Insert(Movie entity);
        void Update(Movie entity);
        void Delete(int id);
    }
}
