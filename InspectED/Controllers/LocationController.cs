using Microsoft.AspNetCore.Mvc;

namespace InspectED.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Add(string name)
        {
            return View();
        }
    }
}
