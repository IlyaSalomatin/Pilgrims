using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Pilgrims.Models
{
    [Serializable]
    public class Human
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Birthday { get; set; }
        public string Planet { get; set; }

        public Human() { }
    }
}