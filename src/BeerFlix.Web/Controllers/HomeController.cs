using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeerFlix.Data.Beers;
using BeerFlix.Web.Common.Enumerable;

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
            var model = new Models.Home.Index();
            model.BeerCount = _beerRepository.GetBeerCount();
            model.BeerStylesCount = _beerRepository.GetBeerStyles().Count();
            model.SelectBeerStyleNames = _beerRepository.GetBeerStyles().Randomize().Take(5).Select(bs => bs.Name);
            model.BeerProducersCount = _beerRepository.GetBeerProducers().Count();
            return View(model);
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