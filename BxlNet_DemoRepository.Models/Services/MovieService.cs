using BxlNet_DemoRepository.Models.Entities;
using BxlNet_DemoRepository.Models.Mappers;
using BxlNet_DemoRepository.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Ado;

namespace BxlNet_DemoRepository.Models.Services
{
    public class MovieService : IMovieRepository
    {
        private readonly DbConnection _connection;

        public MovieService(DbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Movie> GetAll()
        {
            _connection.Open();
            return _connection.ExecuteReader("SELECT Id, Title, [Year], Realisator FROM Movie;", r => r.ToMovie());
        }

        public Movie? GetById(int id)
        {
            _connection.Open();
            return _connection.ExecuteReader("SELECT Id, Title, [Year], Realisator FROM Movie WHERE Id = @Id;", r => r.ToMovie(), parameters: new { id }).SingleOrDefault();
        }

        public void Insert(Movie entity)
        {
            _connection.Open();
            _connection.ExecuteNonQuery("INSERT INTO Movie (Title, [Year], Realisator) VALUES (@Title, @Year, @Realisator);", parameters: new { entity.Title, entity.Year, entity.Realisator });
        }

        public void Update(Movie entity)
        {
            _connection.Open();
            _connection.ExecuteNonQuery("UPDATE Movie SET Title = @Title, [Year] = @Year, Realisator = @Realisator WHERE Id @Id;", parameters: entity);
        }

        public void Delete(int id)
        {
            _connection.ExecuteNonQuery("DELETE FROM Movie WHERE Id = @Id;", parameters: new { id });
        }
    }
}
