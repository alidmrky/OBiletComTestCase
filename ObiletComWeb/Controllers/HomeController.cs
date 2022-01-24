using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ObiletCom.Services.Abstract;
using ObiletComWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ObiletComWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly ILocationService _locationService;
        private readonly IJourneyService _journeyService;
        public HomeController(ISessionService sessionService, ILocationService locationService, IJourneyService journeyService)
        {
            _sessionService = sessionService;
            _locationService = locationService;
            _journeyService = journeyService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> busLocations = new List<SelectListItem>();

            var response = _locationService.GetBusLocations();

            foreach (var item in response.Result.Data)
            {
                busLocations.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.BusLocationList = new SelectList(busLocations, "Value", "Text");
            ViewBag.CurrentDate = DateTime.Now;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
