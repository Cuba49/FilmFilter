using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MovieViewModel
    {
        [System.ComponentModel.DisplayName("Title")]
        public string Title { get; set; }

        [System.ComponentModel.DisplayName("Year")]
        public string Year { get; set; }

        [System.ComponentModel.DisplayName("Country")]
        public string Country { get; set; }

        [System.ComponentModel.DisplayName("Genre")]
        public string Genre { get; set; }

        [System.ComponentModel.DisplayName("Summary")]
        public string Summary { get; set; }

        [System.ComponentModel.DisplayName("Director")]
        public string Director { get; set; }

        [System.ComponentModel.DisplayName("Actor")]
        public string Actors { get; set; }
    }
}
