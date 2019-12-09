using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDB.net.Class
{
    public class Result
    {
        public string profilePath { get; set; }
        public bool adult { get; set; }
        public int id { get; set; }
        public List<KnownFor> knownFor { get; set; }
        public string name { get; set; }
        public double popularity { get; set; }
    }
}