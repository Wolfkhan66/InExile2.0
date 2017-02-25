using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InExile.Models
{
    public class GuideLocation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Additional { get; set; }

        public GuideLocation(string name, string description, string additional)
        {
            Name = name;
            Description = description;
            Additional = additional;
        }
    }
}