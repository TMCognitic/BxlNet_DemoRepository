using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Commands;

namespace BxlNet_DemoRepository.Models.Commands
{
    public class DeleteMovieCommand : ICommandDescription
    {
        public int Id { get; init; }

        public DeleteMovieCommand(int id)
        {
            Id = id;
        }
    }
}
