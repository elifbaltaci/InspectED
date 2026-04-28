using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace InspectED.ViewModels
{
    public class DeviceViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Asset Tag")]
        public string AssetTag { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Device Model")]
        public string DeviceModel { get; set; } = string.Empty;

        [Display(Name = "Assigned User Email")]
        [EmailAddress]
        public string? AssignedUserEmail { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        public string? Location { get; set; }

        public IEnumerable<SelectListItem>? Locations { get; set; }

        public string? ScreenCondition { get; set; }

        public string? KeyboardCondition { get; set; }

        public string? BatteryCondition { get; set; }

        public bool ChargerAvailable { get; set; }

        public bool WifiWorking { get; set; }

        public bool TestingReady { get; set; }

        [DataType(DataType.Date)]
        public DateTime InspectionDate { get; set; } = DateTime.Today;

        public string? Notes { get; set; }
    }
}