using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        //This method calls the TheMovieDb API once more, and this time it passes the actors id to it.
        //The API sends back the JSON containing the complete information of the given actors.

        public ActionResult Index(int id)
        {

            /*Calling API https://developers.themoviedb.org/3/movie */
            string apiKey = "28f726d76e551a93fd511f2360befa56";
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
