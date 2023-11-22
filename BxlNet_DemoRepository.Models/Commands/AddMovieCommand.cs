using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.CQS.Commands;

namespace BxlNet_DemoRepository.Models.Commands
{
    public class AddMovieCommand : ICommandDescription
    {
        public string Title { get; init; }
        public int Year { get; init; }
        public string Realisator { get; init; }

        public AddMovieCommand(string title, int year, string realisator)
        {
            Title = title;
            Year = year;
            Realisator = realisator;
        }
    }
}
