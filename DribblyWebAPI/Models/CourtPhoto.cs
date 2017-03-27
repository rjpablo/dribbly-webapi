using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DribblyWebAPI.Models
{
    public class CourtPhoto
    {
        public int id { get; set; }

        public int userId { get; set; }

        public string fileName { get; set; }

        public DateTime dateUploaded { get; set; }

    }
}