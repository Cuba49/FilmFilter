using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FilmFilter.Models
{
    public class Person
    {
        [XmlElement(ElementName = "last_name")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "first_name")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "birth_date")]
        public string BirthDate { get; set; }

        public override string ToString()
        {
          return  $"{FirstName} {LastName}";
        }
    }
}
