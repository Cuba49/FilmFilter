using FilmFilter.Models;
using Filter.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorFilter
{
    public class DirectorFilter : IFilter
    {
        public string Name => "Director Filter";

        public List<Movie> GetByFilter(List<Movie> movies, List<string> filters)
        {
            return movies.Where(x => filters.Contains(x.Director.ToString())).ToList();
        }

        public List<string> GetListFilter(List<Movie> movies)
        {
            return movies.Select(x => x.Director.ToString()).Distinct().ToList();
        }
    }
}
