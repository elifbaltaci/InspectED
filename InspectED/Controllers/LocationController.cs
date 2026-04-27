using Microsoft.AspNetCore.Mvc;
using InspectED.Data;
using InspectED.Models;
using InspectED.ViewModels;

namespace InspectED.Controllers
{
    public class LocationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(LocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var location = new Location
                {
                    Name = model.Name,
                    Description = model.Description
                };

                _context.Locations.Add(location);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}