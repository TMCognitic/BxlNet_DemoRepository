using BxlNet_DemoRepository.Models.Entities;
using BxlNet_DemoRepository.Models.Repositories;
using BxlNet_DemoRepository.Models.Services;

namespace BxlNet_DemoRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMovieRepository repository = new FakeMovieService();

            foreach (Movie item in repository.GetAll())
            {
                Console.WriteLine($"{item.Id} : {item.Title}");
            }
        }
    }
}
