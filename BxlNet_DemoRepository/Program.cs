using BxlNet_DemoRepository.Models.Entities;
using BxlNet_DemoRepository.Models.Repositories;
using BxlNet_DemoRepository.Models.Services;
using System.Data.Common;
using System.Data.SqlClient;

namespace BxlNet_DemoRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(DbConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=GestMovie;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                IMovieRepository repository = new MovieService(connection);

                //foreach (Movie item in repository.GetAll())
                //{
                //    Console.WriteLine($"{item.Id} : {item.Title}");
                //}

                //Movie? movie = repository.GetById(1);

                //if(movie is not null)
                //{
                //    Console.WriteLine(movie.Title);
                //}

                Movie newMovie = new Movie() { Title = "Le seigneur des agneaux", Year = 2001, Realisator = "Peter Jackson" };
                repository.Insert(newMovie);
            }
        }
    }
}
