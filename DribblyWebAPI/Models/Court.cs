using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DribblyWebAPI.Models
{
    public class Court
    {
        public int id { get; set; }

        public string name { get; set; }

        public string contactNo { get; set; }

        public string address { get; set; }

        public string description { get; set; }

        public double rate { get; set; }

        public string imagePath { get; set; }

    }
}