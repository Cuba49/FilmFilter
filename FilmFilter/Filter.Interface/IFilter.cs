using FilmFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter.Interface
{
    public interface IFilter
    {
        List<string> GetListFilter(List<Movie> movies);
        List<Movie> GetByFilter(List<Movie> movies, List<string> filters);
        string Name { get; }
    }
}
