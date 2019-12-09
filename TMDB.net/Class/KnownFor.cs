using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDB.net.Class
{
    public class KnownFor
    {
        public string posterPath { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string releaseDate { get; set; }
        public string originalTitle { get; set; }
        public List<object> genreIds { get; set; }
        public int id { get; set; }
        public string mediaType { get; set; }
        public string originalLanguage { get; set; }
        public string title { get; set; }
        public string backdropPath { get; set; }
        public double popularity { get; set; }
        public int voteCount { get; set; }
        public bool video { get; set; }
        public double voteAverage { get; set; }
        public string firstAirDate { get; set; }
        public List<string> originCountry { get; set; }
        public string name { get; set; }
        public string originalName { get; set; }
    }
}