using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InExile.Models
{
    public class GuideItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Additional { get; set; }

        public GuideItem(string name, string description, string additional)
        {
            Name = name;
            Description = description;
            Additional = additional;
        }
    }
}