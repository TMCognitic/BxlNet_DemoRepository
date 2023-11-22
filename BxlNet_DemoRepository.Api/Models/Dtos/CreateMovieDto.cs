using System.ComponentModel.DataAnnotations;

namespace BxlNet_DemoRepository.Api.Models.Dtos
{
#nullable disable
    public class CreateMovieDto
    {
        [Required]
        [MinLength(1)]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [MinLength(1)]
        public string Realisator { get; set; }
    }
}
