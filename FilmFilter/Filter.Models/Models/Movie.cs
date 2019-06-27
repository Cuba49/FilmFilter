using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FilmFilter.Models
{
    [XmlRoot(ElementName = "movie")]
    public class Movie
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "year")]
        public string Year { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "genre")]
        public string Genre { get; set; }
        [XmlElement(ElementName = "summary")]
        public string Summary { get; set; }
        [XmlElement(ElementName = "director")]
        public Director Director { get; set; }
        [XmlElement(ElementName = "actor")]
        public List<Actor> Actors { get; set; }
    }

    [XmlRoot(ElementName = "movies")]
    public class Movies
    {
        [XmlElement(ElementName = "movie")]
        public List<Movie> MovieList { get; set; }
    }
}
