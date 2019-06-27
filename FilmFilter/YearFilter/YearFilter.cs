using FilmFilter.Models;
using Filter.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearFilter
{
    public class YearFilter : IFilter
    {
        public string Name => "Year Filter";

        public List<Movie> GetByFilter(List<Movie> movies, List<string> filters)
        {
            return movies.Where(x => filters.Contains(x.Year)).ToList();
        }

        public List<string> GetListFilter(List<Movie> movies)
        {
            return movies.Select(x => x.Year).Distinct().ToList();
        }
    }
    

}
