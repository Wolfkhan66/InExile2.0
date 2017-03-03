using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InExile.Models
{
    public class GuideEditModel
    {
        public Dictionary<string, object> Dictionary { get; set; }
        public string Type { get; set; }

        public GuideEditModel(Dictionary<string, object> dictionary, string type)
        {
            Dictionary = dictionary;
            Type = type;
        }
    }
}