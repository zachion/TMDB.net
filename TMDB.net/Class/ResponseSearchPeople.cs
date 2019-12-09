using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDB.net.Class
{
    public class ResponseSearchPeople
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
        public int totalResults { get; set; }
        public int totalPages { get; set; }
    }
}