using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace InExile.Models
{
    public class GuideViewModel
    {
        public DataTable Table { get; set; }
        public string Type { get; set; }

        public GuideViewModel(DataTable table, string type)
        {
            Table = table;
            Type = type;
        }
    }
}