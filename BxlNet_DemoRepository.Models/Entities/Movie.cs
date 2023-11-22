using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BxlNet_DemoRepository.Models.Entities
{
#nullable disable
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Realisator { get; set; }
    }
}
