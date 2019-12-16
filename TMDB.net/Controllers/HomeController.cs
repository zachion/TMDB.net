﻿using Newtonsoft.Json;
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
    public class HomeController : Controller
    {
        // GET: Popular

        //we are using this method for doing the actor search (by their names) through this API.
        //The parameter called peopleName contains the value of the text box(that contains actor’s name), 
        //the parameter called page contains the current page number as given in the URL.
        //Consider – If the URL is ‘http://localhost:64253/TmdbApi/nicole/1’ then ‘peopleName’ will receive value of ‘nicole’ 
        //while ‘page’ will receive the value of ‘1’.
        // GET
        public ActionResult Index(int? page)
        {
            var popularMoviesResponse = new PopularMoviesResponse();

            if (page != null)
                popularMoviesResponse = GetPupular(Convert.ToInt32(page));

            //Models.NewMoviePageResponse theMovieDb = new Models.NewMoviePageResponse();


            int pageNo = Convert.ToInt32(page) == 0 ? 1 : Convert.ToInt32(page);
            int pageSize = 20;
            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.currentPage = pageNo;
            pagingInfo.totalItems = popularMoviesResponse.total_results;
            pagingInfo.itemsPerPage = pageSize;
            ViewBag.Paging = pagingInfo;

            return View(popularMoviesResponse);
        }

        [HttpPost]
        public ActionResult Index(Models.TheMovieDb theMovieDb, string searchText)
        {
            if (ModelState.IsValid)
            {
                GetPupular(1);
            }
            return View(theMovieDb);
        }

        //This method calls CallAPI() which will make the actual API call.
        //I have passed the ‘name’ of the actor and the ‘page number’ to this method.
        //It makes the call to the CallAPI() method.I pass the actor name and ‘0’ for the page number, 
        //telling it to get me the 1st page for the search result.
        public PopularMoviesResponse GetPupular(int page)
        {


            /*Calling API https://developers.themoviedb.org/3/movie/popular */
            //string apiKey = "3356865d41894a2fa9bfa84b2b5f59bb";
            string apiKey = "28f726d76e551a93fd511f2360befa56";
            HttpWebRequest apiRequest = WebRequest.Create("https://api.themoviedb.org/3/movie/popular?api_key=" + apiKey +
                "&language=en-US&page=" + page + "&include_adult=false") as HttpWebRequest;

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

            PopularMoviesResponse rootObject = JsonConvert.DeserializeObject<PopularMoviesResponse>(apiResponse);
            return rootObject;

        }
    }
}