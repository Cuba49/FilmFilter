using FilmFilter.Models;
using Filter.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenreFilter
{
    public class GenreFilter : IFilter
    {
        public string Name => "Genre Filter";

        public List<Movie> GetByFilter(List<Movie> movies, List<string> filters)
        {
            return movies.Where(x => filters.Contains(x.Genre)).ToList();
        }

        public List<string> GetListFilter(List<Movie> movies)
        {
            return movies.Select(x => x.Genre).Distinct().ToList();
        }
    }
}
