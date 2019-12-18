using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMDB.net.Models;

namespace TMDB.net.Controllers
{
    public class MovieDetailsController : Controller
    {
        // GET: Movie
        //This method calls the TheMovieDb API once more, and this time it passes the movie id to it.
        //The API sends back the JSON containing the complete information of the given movie.

        public ActionResult Index(int id)
        {

            /*Calling API https://developers.themoviedb.org/3/movie */
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            HttpWebRequest apiRequest = WebRequest.Create("https://api.themoviedb.org/3/movie/" + id +
                "?api_key=" + apiKey + "&language=en-US") as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            /*End*/

            /*http://json2csharp.com*/
            MovieInformation movieInformation = JsonConvert.DeserializeObject<MovieInformation>(apiResponse);

            return View(movieInformation);
        }
    }
}
