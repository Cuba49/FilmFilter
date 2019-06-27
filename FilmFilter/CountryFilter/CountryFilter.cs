using FilmFilter.Models;
using Filter.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryFilter
{
    public class CountryFilter : IFilter
    {
        public string Name => "Country Filter";

        public List<Movie> GetByFilter(List<Movie> movies, List<string> filters)
        {
            return movies.Where(x => filters.Contains(x.Country)).ToList<Movie>();
        }

        public List<string> GetListFilter(List<Movie> movies)
        {
            return movies.Select(x => x.Country).Distinct().ToList();
        }
    }
}
