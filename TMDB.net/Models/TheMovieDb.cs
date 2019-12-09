using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMDB.net.Models
{
    public class TheMovieDb
    {
        [Required]
        public string searchText { get; set; }
        public bool adult { get; set; }
        public string alsoKnownAs { get; set; }
        public string biography { get; set; }
        public string birthday { get; set; }
        public string deathday { get; set; }
        public int gender { get; set; }
        public string homePage { get; set; }
        public int id { get; set; }
        public string imdbId { get; set; }
        public string name { get; set; }
        public string placeOfBirth { get; set; }
        public double popularity { get; set; }
        public string profilePath { get; set; }
    }
}