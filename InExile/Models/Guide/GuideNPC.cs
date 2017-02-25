using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InExile.Models
{
    public class GuideNPC
    {
        public string Name { get; set; }
        public string Appearance { get; set; }
        public string Location { get; set; }
        public string Additional { get; set; }

        public GuideNPC(string name, string appearance,string location, string additional)
        {
            Name = name;
            Appearance = appearance;
            Location = location;
            Additional = additional;
        }
    }
}