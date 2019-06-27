using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FilmFilter.Models
{
    [XmlRoot(ElementName = "actor")]
    public class Actor : Person
    {
        [XmlElement(ElementName = "role")]
        public string Role { get; set; }
    }
}
