using BxlNet_DemoRepository.Models.Commands;
using BxlNet_DemoRepository.Models.Entities;
using BxlNet_DemoRepository.Models.Queries;
using Tools.CQS.Commands;
using Tools.CQS.Queries;

namespace BxlNet_DemoRepository.Models.Repositories
{
    public interface IMovieRepository : 
        ICommandHandler<AddMovieCommand>,
        ICommandHandler<DeleteMovieCommand>,
        IQueryHandler<GetAllMovieQuery, IEnumerable<Movie>>,
        IQueryHandler<GetMovieByIdQuery, Movie>
    {
    }
}
