using BxlNet_DemoRepository.Models.Entities;
using System.Data;

namespace BxlNet_DemoRepository.Models.Mappers
{
    internal static class Mappers
    {
        internal static Movie ToMovie(this IDataRecord reader)
        {
            return new Movie()
            {
                Id = (int)reader["Id"],
                Title = (string)reader["Title"],
                Year = (int)reader["Year"],
                Realisator = (string)reader["Realisator"]
            };
        }
    }
}
