using FilmFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace FilmFilter
{
    public static class Mapper
    {
        public static List<MovieViewModel> GenerateModelToView(List<Movie> movies)
        {
            var result = movies.Select(movie =>
                new MovieViewModel()
                {
                    Title = movie.Title,
                    Country = movie.Country,
                    Genre = movie.Genre,
                    Summary = movie.Summary,
                    Year = movie.Year,
                    Director = movie.Director.ToString(),
                    Actors = String.Join(", ", movie.Actors.Select(x => x.ToString()))
                }
            ).ToList();
            return result;
        }
    }
}
