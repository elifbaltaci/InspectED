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

        public async Task<IActionResult> Index(
    string searchString,
    string sortOrder,
    int pageNumber = 1,
    string currentFilter = "")
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["AssetTagSortParam"] = string.IsNullOrEmpty(sortOrder) ? "assetTag_desc" : "";
            ViewData["SerialNumberSortParam"] = sortOrder == "serial_asc" ? "serial_desc" : "serial_asc";
            ViewData["ModelSortParam"] = sortOrder == "model_asc" ? "model_desc" : "model_asc";
            ViewData["LocationSortParam"] = sortOrder == "location_asc" ? "location_desc" : "location_asc";
            ViewData["ReadySortParam"] = sortOrder == "ready_asc" ? "ready_desc" : "ready_asc";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var devices = _deviceRepository.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                devices = devices.Where(d =>
                    d.AssetTag.Contains(searchString) ||
                    d.SerialNumber.Contains(searchString) ||
                    d.DeviceModel.Contains(searchString) ||
                    d.AssignedUserEmail.Contains(searchString) ||
                    d.Location.Contains(searchString)
                );
            }

            devices = sortOrder switch
            {
                "assetTag_desc" => devices.OrderByDescending(d => d.AssetTag),
                "serial_asc" => devices.OrderBy(d => d.SerialNumber),
                "serial_desc" => devices.OrderByDescending(d => d.SerialNumber),
                "model_asc" => devices.OrderBy(d => d.DeviceModel),
                "model_desc" => devices.OrderByDescending(d => d.DeviceModel),
                "location_asc" => devices.OrderBy(d => d.Location),
                "location_desc" => devices.OrderByDescending(d => d.Location),
                "ready_asc" => devices.OrderBy(d => d.TestingReady),
                "ready_desc" => devices.OrderByDescending(d => d.TestingReady),
                _ => devices.OrderBy(d => d.AssetTag)
            };

            if (pageNumber <1)
            {
                pageNumber = 1;
            }

            int pageSize = 10;

            return View(await PaginatedList<DeviceViewModel>.CreateAsync(devices, pageNumber, pageSize));
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