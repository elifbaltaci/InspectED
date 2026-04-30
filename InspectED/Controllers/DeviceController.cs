using InspectED.Models;
using InspectED.Repositories;
using InspectED.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

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


        // GET: Device/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var device = await _deviceRepository.GetByIdAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            var deviceViewModel = new DeviceViewModel
            {
                Id = device.Id,
                AssetTag = device.AssetTag,
                SerialNumber = device.SerialNumber,
                DeviceModel = device.DeviceModel,
                AssignedUserEmail = device.AssignedUserEmail,
                LocationId = device.LocationId,
                ScreenCondition = device.ScreenCondition,
                KeyboardCondition = device.KeyboardCondition,
                BatteryCondition = device.BatteryCondition,
                ChargerAvailable = device.ChargerAvailable,
                WifiWorking = device.WifiWorking,
                TestingReady = device.TestingReady,
                InspectionDate = device.InspectionDate,
                Notes = device.Notes,

                Locations = await _deviceRepository.GetLocationsAsync()
            };

            return View(deviceViewModel);
        }

        // POST: Device/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DeviceViewModel deviceViewModel)
        {
            if (!ModelState.IsValid)
            {
                deviceViewModel.Locations = await _deviceRepository.GetLocationsAsync();
                return View(deviceViewModel);
            }

            var device = new Device
            {
                Id = deviceViewModel.Id,
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

            await _deviceRepository.UpdateAsync(device);
            await _deviceRepository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Device/Delete
        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            await _deviceRepository.DeleteAsync(id);
            return RedirectToAction("Index", "Device");
        }

    }
}