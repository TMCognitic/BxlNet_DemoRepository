using BxlNet_DemoRepository.Models.Commands;
using BxlNet_DemoRepository.Models.Entities;
using BxlNet_DemoRepository.Models.Mappers;
using BxlNet_DemoRepository.Models.Queries;
using BxlNet_DemoRepository.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Ado;
using Tools.CQS;
using Tools.CQS.Queries;

namespace BxlNet_DemoRepository.Models.Services
{
    public class MovieService : IMovieRepository
    {
        private readonly DbConnection _connection;

        public MovieService(DbConnection connection)
        {
            _connection = connection;
        }

        public ICommandResult Execute(AddMovieCommand command)
        {
            try
            {
                _connection.Open();
                int rows = _connection.ExecuteNonQuery("INSERT INTO Movie (Title, [Year], Realisator) VALUES (@Title, @Year, @Realisator);", parameters: command);

                if (rows != 1)
                    return CommandResult.Failure($"Nombre de ligne modifiée invalide : {rows} ligne(s)");

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message);
            }
        }

        public ICommandResult Execute(DeleteMovieCommand command)
        {
            try
            {
                _connection.Open();
                int rows = _connection.ExecuteNonQuery("DELETE FROM Movie WHERE Id = @Id;", parameters: command);

                if (rows != 1)
                    return CommandResult.Failure($"Nombre de ligne modifié invalide : {rows} ligne(s)");

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message);
            }
        }

        public IQueryResult<IEnumerable<Movie>> Execute(GetAllMovieQuery query)
        {
            try
            {
                _connection.Open();
                IEnumerable<Movie> movies = _connection.ExecuteReader("SELECT Id, Title, [Year], Realisator FROM Movie;", r => r.ToMovie()).ToList();

                return QueryResult<IEnumerable<Movie>>.Success(movies);
            }
            catch (Exception ex)
            {
                return QueryResult<IEnumerable<Movie>>.Failure(ex.Message);
            }
        }

        public IQueryResult<Movie> Execute(GetMovieByIdQuery query)
        {
            try
            {
                _connection.Open();
                Movie? movie = _connection.ExecuteReader("SELECT Id, Title, [Year], Realisator FROM Movie WHERE Id = @Id;", r => r.ToMovie(), parameters: query).SingleOrDefault();

                if (movie is null)
                    return QueryResult<Movie>.Failure("Pas de film avec cet Id");

                return QueryResult<Movie>.Success(movie);
            }
            catch (Exception ex)
            {
                return QueryResult<Movie>.Failure(ex.Message);
            }
        }

        //public IEnumerable<Movie> GetAll()
        //{
        //    _connection.Open();
        //    return _connection.ExecuteReader("SELECT Id, Title, [Year], Realisator FROM Movie;", r => r.ToMovie());
        //}

        //public Movie? GetById(int id)
        //{
        //    _connection.Open();
        //    return _connection.ExecuteReader("SELECT Id, Title, [Year], Realisator FROM Movie WHERE Id = @Id;", r => r.ToMovie(), parameters: new { id }).SingleOrDefault();
        //}

        //public void Insert(Movie entity)
        //{
        //    _connection.Open();
        //    _connection.ExecuteNonQuery("INSERT INTO Movie (Title, [Year], Realisator) VALUES (@Title, @Year, @Realisator);", parameters: new { entity.Title, entity.Year, entity.Realisator });
        //}

        //public void Update(Movie entity)
        //{
        //    _connection.Open();
        //    _connection.ExecuteNonQuery("UPDATE Movie SET Title = @Title, [Year] = @Year, Realisator = @Realisator WHERE Id @Id;", parameters: entity);
        //}

        //public void Delete(int id)
        //{
        //    _connection.ExecuteNonQuery("DELETE FROM Movie WHERE Id = @Id;", parameters: new { id });
        //}

    }
}
