using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class Instrument
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int UsedPrice { get; set; }
        public int NewPrice { get; set; }
        public string ImageURL { get; set; }
    }
}