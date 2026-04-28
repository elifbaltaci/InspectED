using Microsoft.AspNetCore.Mvc;
using InspectED.Models;
using InspectED.ViewModels;
using InspectED.Repositories;

namespace InspectED.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IActionResult> Index()
        {
            var locations = await _locationRepository.GetAllAsync();
            return View(locations);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new LocationViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(LocationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool locationExists = await _locationRepository.LocationExistsAsync(model.Name);

            if (locationExists)
            {
                ModelState.AddModelError("Name", "This location already exists.");
                return View(model);
            }

            var location = new Location
            {
                Name = model.Name
            };

            await _locationRepository.AddAsync(location);
            await _locationRepository.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}