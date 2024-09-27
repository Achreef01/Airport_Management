using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        private readonly IServiceFlight _flightService;
        private readonly IServicePlane _planeService;

        public FlightController(IServiceFlight flightService, IServicePlane planeService)
        {
            _flightService = flightService;
            _planeService = planeService;
        }
        // GET: FlightController

        //public ActionResult Index()
        //{
        //    return View(_flightService
        //            .GetAll());
        //}
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
            {
                return View(_flightService
                    .GetAll());
            }
            else
            {
                return View(_flightService
                    .GetMany(f => f.FlightDate == dateDepart));
            }
        }
        public ActionResult Sort()
        {
            return View("Index", _flightService.SortFlights());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.Planes = new SelectList(_planeService.GetAll().ToList(),
                "PlaneId", "PlaneId");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight, IFormFile Pilot)
        {
            try
            {
                if (Pilot != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", Pilot.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    Pilot.CopyTo(stream);
                    flight.Pilot = Pilot.FileName;
                }
                _flightService.Add(flight);
                _flightService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
