using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz4.Entities;
using Quiz4.Models;
using System.Diagnostics;

namespace Quiz4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Private DbContext for BPMeasurements.
        private BPMeasurementsContext _bpMeasurementsContext;

        // Initialize BPMeasurements in the constructor.
        public HomeController(ILogger<HomeController> logger, BPMeasurementsContext bpMeasurementsContext)
        {
            _logger = logger;
            _bpMeasurementsContext = bpMeasurementsContext; 
        }

        // Pass a list of BPMeasurements into the Index view.
        public IActionResult Index()
        {
            // Create list of Bpmeasurements.
            List<Bpmeasurement> measurements = _bpMeasurementsContext.Bpmeasurements
                .Include(b => b.MeasurementPosition)
                .OrderByDescending(b => b.MeasurementDate)
                .ToList();

            // Return list in view.
            return View("Index", measurements);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
