using Newtonsoft.Json.Linq;
using StarWarsAPIPractice.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StarWarsAPIPractice.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}
        
        public ActionResult Index()
        {
            string URL = $"https://swapi.co/api/people/3";

            HttpWebRequest request = WebRequest.CreateHttp(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();

            JToken jsonpeopleCount = JToken.Parse(APIText);

            JToken jsonSW = JToken.Parse(APIText);
            FilmEndpoints f = new FilmEndpoints();

            f.Name = jsonSW["name"].ToString();
            f.Height = jsonSW["height"].ToString();
            f.Mass = jsonSW["mass"].ToString();
            f.HairColor = jsonSW["hair_color"].ToString();
            f.Films = jsonSW["films"].ToString();

            //List<string> listEndpoints = new List<string>();

            //ViewBag.FilmEndpoints = f;

            return View(f);
        }
    }
}