using InspectED.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InspectED.Models;
using InspectED.Data;

namespace InspectED.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Seed Locations
        private void SeedLocations()
        {
            var defaultLocations = new List<string>
    {
        "1/A", "1/B",
        "2/A", "2/B",
        "3/A", "3/B",
        "4/A", "4/B",
        "5/A", "5/B"
    };

            foreach (var name in defaultLocations)
            {
                bool exists = _context.Locations
                    .Any(l => l.Name.ToLower().Trim() == name.ToLower().Trim());

                if (!exists)
                {
                    _context.Locations.Add(new Location { Name = name });
                }
            }

            _context.SaveChanges();
        }

        // GET: Add Device
        [HttpGet]
        public IActionResult Add()
        {
            SeedLocations(); 

            ViewBag.Locations = _context.Locations
                .OrderBy(l => l.Name)
                .Select(l => new SelectListItem
                {
                    Value = l.LocationId.ToString(),
                    Text = l.Name
                })
                .ToList();

            return View(new DeviceViewModel());
        }

        // POST: Add Device
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(DeviceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var device = new Device
                {
                    AssetTag = model.AssetTag,
                    SerialNumber = model.SerialNumber,
                    Model = model.Model,
                    AssignedUserEmail = model.AssignedUserEmail,
                    LocationId = model.LocationId,
                    ScreenCondition = model.ScreenCondition,
                    KeyboardCondition = model.KeyboardCondition,
                    BatteryCondition = model.BatteryCondition,
                    ChargerAvailable = model.ChargerAvailable,
                    WifiWorking = model.WifiWorking,
                    TestingReady = model.TestingReady,
                    InspectionDate = model.InspectionDate,
                    Notes = model.Notes
                };

                _context.Devices.Add(device);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // reload dropdown if validation fails
            ViewBag.Locations = _context.Locations
                .Select(l => new SelectListItem
                {
                    Value = l.LocationId.ToString(),
                    Text = l.Name
                })
                .ToList();

            return View(model);
        }
    }
}