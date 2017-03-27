﻿using System;
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

        public double latitude { get; set; }

        public double longitude { get; set; }

        public int cityId { get; set; }

        /// <summary>
        /// The id of the user who registered this court.
        /// </summary>
        public int userId { get; set; }

        public DateTime dateRegistered { get; set; }

    }
}