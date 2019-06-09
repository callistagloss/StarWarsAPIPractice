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
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string peopleCount, int Id)
        {
            peopleCount = "https://swapi.co/api/";

            HttpWebRequest request = WebRequest.CreateHttp(peopleCount);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();

            JToken jsonpeopleCount = JToken.Parse(APIText);

            int count = (int)jsonpeopleCount["count"];

            if (Id < 1)
            {
                ViewBag.Message = "That person doesn't exist.";
                    return View("Index");
            }

            string StarWarsURL = $"https://swapi.co/api/";

            request = WebRequest.CreateHttp(StarWarsURL);
            response = (HttpWebResponse)request.GetResponse();
            rd = new StreamReader(response.GetResponseStream());
            APIText = rd.ReadToEnd();

            JToken jsonSW = JToken.Parse(APIText);
            FilmEndpoints f = new FilmEndpoints();

            f.People = jsonSW["people"].ToString();
            f.Name = jsonSW["name"].ToString();
            f.Height = (int)jsonSW["height"];
            f.Mass = (int)jsonSW["mass"];
            f.HairColor = jsonSW["hair_color"].ToString();
            f.Films = jsonSW["films"].ToString();
            

            //if (jsonSW[")

            List<string> listEndpoints = new List<string>();

            if (listEndpoints != null)
            {
                foreach (JToken jt in listEndpoints)
                {
                    f.People = jsonSW["people"].ToString();
                    f.Name = jsonSW["name"].ToString();
                    f.Height = (int)jsonSW["height"];
                    f.Mass = (int)jsonSW["mass"];
                    f.HairColor = jsonSW["hair_color"].ToString();
                    f.Films = jsonSW["films"].ToString();

                    listEndpoints.Add(jt.ToString());
                }
            }
            ViewBag.FilmEndpoints = f;

            return View(f);
        }
    }
}