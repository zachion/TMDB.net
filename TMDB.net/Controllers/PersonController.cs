using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TMDB.net.Class;
using TMDB.net.Models;

namespace TMDB.net.Controllers
{
    public class PersonController : Controller
    {
        // GET: TmdbApi
        public ActionResult Index(string actorName, int? page)
        {
            if (actorName == null)
                return View(new SearchActorsResponse());

            int pageNo = Convert.ToInt32(page) == 0 ? 1 : Convert.ToInt32(page);

            string name = actorName == null ? "" : actorName;

            var searchActorsResponse = GetActors(name, Convert.ToInt32(pageNo));

            searchActorsResponse.searchText = name;
            return View(searchActorsResponse);
        }

        [HttpPost]
        public ActionResult Index(Models.TheMovieDb theMovieDb, string searchText)
        {
            var searchActorsResponse = new SearchActorsResponse();

            if (ModelState.IsValid)
            {
                searchActorsResponse = GetActors(searchText, 0);
            }


            return View(searchActorsResponse);
        }
        public SearchActorsResponse GetActors(string searchText, int page)
        {
            int pageNo = Convert.ToInt32(page) == 0 ? 1 : Convert.ToInt32(page);

            /*Calling API https://developers.themoviedb.org/3/search/search-people */
            string apiKey = "28f726d76e551a93fd511f2360befa56";
            HttpWebRequest apiRequest = WebRequest.Create("https://api.themoviedb.org/3/search/person?api_key=" + apiKey + "&language=en-US&query=" + searchText + "&page=" + pageNo + "&include_adult=false") as HttpWebRequest;

            string apiResponse = "";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
                    | SecurityProtocolType.Tls
                    | SecurityProtocolType.Tls11
                    | SecurityProtocolType.Tls12;
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            /*End*/

            /*http://json2csharp.com*/

            SearchActorsResponse rootObject = JsonConvert.DeserializeObject<SearchActorsResponse>(apiResponse);


            int pageSize = 20;
            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.currentPage = pageNo;
            pagingInfo.totalItems = rootObject.total_results;
            pagingInfo.itemsPerPage = pageSize;
            ViewBag.Paging = pagingInfo;

            return rootObject;

        }

        public ActionResult GetPerson(int id)
        {
            /*Calling API https://developers.themoviedb.org/3/people */
            string apiKey = "28f726d76e551a93fd511f2360befa56";
            HttpWebRequest apiRequest = WebRequest.Create("https://api.themoviedb.org/3/person/" + id + "?api_key=" + apiKey + "&language=en-US") as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            /*End*/

            /*http://json2csharp.com*/
            ResponsePerson rootObject = JsonConvert.DeserializeObject<ResponsePerson>(apiResponse);
            TheMovieDb theMovieDb = new TheMovieDb();
            theMovieDb.name = rootObject.name;
            theMovieDb.biography = rootObject.biography;
            theMovieDb.birthday = rootObject.birthday;
            theMovieDb.placeOfBirth = rootObject.place_of_birth;
            theMovieDb.profilePath = rootObject.profile_path == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + rootObject.profile_path;
            theMovieDb.alsoKnownAs = string.Join(", ", rootObject.also_known_as);

            return View(theMovieDb);
        }
    }
}