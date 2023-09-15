using HMS.Services;
using HMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            AccomodationTypesService service = new AccomodationTypesService();
            AccomodationPackagesService accomodationPackagesService = new AccomodationPackagesService();
            model.AccomodationTypes = service.GetAllAccomodationTypes();
            model.AccomodationPackages = accomodationPackagesService.GetAllAccomodationPackages();
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