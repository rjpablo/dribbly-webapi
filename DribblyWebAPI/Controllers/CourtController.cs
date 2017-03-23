using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DribblyWebAPI.Models;
using System.Web.Configuration;

namespace DribblyWebAPI.Controllers
{
    public class CourtController : ApiController
    {
        public IHttpActionResult GetCourts()
        {
            var games = new List<Court>();
            string imageUploadPath = WebConfigurationManager.AppSettings["imageUploadPath"];

            games.Add(new Court(){
                id =1,
                name = "ABC Basketball Court",
                description ="Just some long long long description.",
                address ="#123 Kanto St. Sampaloc Manila",
                contactNo ="0923-765-9876",
                rate =100.00,
                imagePath= "1.jpg"
            });

            games.Add(new Court()
            {
                id = 2,
                name = "Monster Ballers Basketball Court",
                description = "Just some long long long description.",
                address = "#12 Ben Harrison St. Brgy. Pio del Pilar, Makati City, Metro Manila",
                contactNo = "0923-765-9876",
                rate = 100.00,
                imagePath = "2.jpg"
            });

            games.Add(new Court()
            {
                id = 3,
                name = "Monster Ballers Basketball Court",
                description = "Just some long long long description.",
                address = "#12 Don Juan St. Brgy. Palanan, Makati City, Metro Manila",
                contactNo = "0923-765-9854",
                rate = 100.00,
                imagePath = "3.jpg"
            });

            games.Add(new Court()
            {
                id = 4,
                name = "Monster Ballers Basketball Court",
                description = "Just some long long long description.",
                address = "#12 Ben Harrison St. Brgy. Pio del Pilar, Makati City, Metro Manila",
                contactNo = "0923-765-9876",
                rate = 100.00,
                imagePath = "4.jpg"
            });

            games.Add(new Court()
            {
                id = 5,
                name = "Monster Ballers Basketball Court",
                description = "Just some long long long description.",
                address = "#12 Ben Harrison St. Brgy. Pio del Pilar, Makati City, Metro Manila",
                contactNo = "0923-765-9876",
                rate = 100.00,
                imagePath = "5.jpg"
            });

            return Ok(games);
        }
    }
}