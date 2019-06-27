using FilmFilter.Models;
using Filter.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorFilter
{
    public class ActorFilter : IFilter
    {
        public string Name => "Actor Filter";

        public List<Movie> GetByFilter(List<Movie> movies, List<string> filters)
        {
            return movies.Where(x => x.Actors.Any(a => filters.Contains(a.ToString()))).ToList();
        }

        public List<string> GetListFilter(List<Movie> movies)
        {
            return movies.SelectMany(x => x.Actors).Select(x => x.ToString()).Distinct().ToList();
        }
    }
}
