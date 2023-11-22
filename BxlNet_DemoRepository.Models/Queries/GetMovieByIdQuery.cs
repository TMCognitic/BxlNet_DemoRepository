using BxlNet_DemoRepository.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Queries;

namespace BxlNet_DemoRepository.Models.Queries
{
    public class GetMovieByIdQuery : IQueryDescription<Movie>
    {
        public int Id { get; init; }

        public GetMovieByIdQuery(int id)
        {
            Id = id;
        }
    }
}
