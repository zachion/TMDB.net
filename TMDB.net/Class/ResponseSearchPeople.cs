using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDB.net.Class
{
    //I get the result in JSON format which is serialized into the ResponseSearchPeople class. 
    //For doing this Serialization I use the JsonConvert class from namespace Newtonsoft.Json.
    public class ResponseSearchPeople
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
        public int totalResults { get; set; }
        public int totalPages { get; set; }
    }
}