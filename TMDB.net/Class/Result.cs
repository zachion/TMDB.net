using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDB.net.Class
{
    public class Result
    {
        public double popularity { get; set; }
        public string known_for_department { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string profile_path { get; set; }
        public bool adult { get; set; }
        public List<KnownFor> known_for { get; set; }
        public string name { get; set; }
    }
}