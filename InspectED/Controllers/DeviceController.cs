using InspectED.Models;
using InspectED.Repositories;
using InspectED.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InspectED.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<IActionResult> Index()
        {
            var devices = await _deviceRepository.GetAllAsync();
            return View(devices);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            await _deviceRepository.SeedLocationsAsync();

            var deviceViewModel = new DeviceViewModel
            {
                Locations = await _deviceRepository.GetLocationsAsync()
            };

            return View(deviceViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(DeviceViewModel deviceViewModel)
        {
            if (!ModelState.IsValid)
            {
                deviceViewModel.Locations = await _deviceRepository.GetLocationsAsync();
                return View(deviceViewModel);
            }

            var device = new Device
            {
                AssetTag = deviceViewModel.AssetTag,
                SerialNumber = deviceViewModel.SerialNumber,
                DeviceModel = deviceViewModel.DeviceModel,
                AssignedUserEmail = deviceViewModel.AssignedUserEmail,
                LocationId = deviceViewModel.LocationId,
                ScreenCondition = deviceViewModel.ScreenCondition,
                KeyboardCondition = deviceViewModel.KeyboardCondition,
                BatteryCondition = deviceViewModel.BatteryCondition,
                ChargerAvailable = deviceViewModel.ChargerAvailable,
                WifiWorking = deviceViewModel.WifiWorking,
                TestingReady = deviceViewModel.TestingReady,
                InspectionDate = deviceViewModel.InspectionDate,
                Notes = deviceViewModel.Notes
            };

            await _deviceRepository.AddAsync(device);
            await _deviceRepository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}