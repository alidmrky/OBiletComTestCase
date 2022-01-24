using Microsoft.AspNetCore.Mvc;
using ObiletCom.Services.Abstract;
using System;

namespace ObiletComWeb.Controllers
{
    public class JourneyController : Controller
    {
        private readonly IJourneyService _journeyService;
        public JourneyController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
        }
        public IActionResult Index(int origin, int destination, DateTime departureDate)
        {
            if (origin == destination)
                return RedirectToAction("Index", "Home");

            var responseBusJourneys = _journeyService.GetBusJourneys(new ObiletCom.Services.Dtos.GetBusJourneyModelDto()
            {
                DepartureDate = departureDate,
                DestinationId = destination,
                OriginId = origin
            });
            var data = responseBusJourneys.Result.Data;
            return View(data);
        }
    }
}
