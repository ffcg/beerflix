using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeerFlix.Data.Beers;

namespace BeerFlix.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBeerRepository _beerRepository;

        public HomeController(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}