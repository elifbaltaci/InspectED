using System;
using System.ComponentModel.DataAnnotations;

namespace InspectED.Models
{
    public class Device
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

        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public Location? Location { get; set; }

        [Display(Name = "Screen Condition")]
        public string? ScreenCondition { get; set; }

        [Display(Name = "Keyboard Condition")]
        public string? KeyboardCondition { get; set; }

        [Display(Name = "Battery Condition")]
        public string? BatteryCondition { get; set; }

        [Display(Name = "Charger Available")]
        public bool ChargerAvailable { get; set; }

        [Display(Name = "WiFi Working")]
        public bool WifiWorking { get; set; }

        [Display(Name = "Testing Ready")]
        public bool TestingReady { get; set; }

        [Display(Name = "Inspection Date")]
        [DataType(DataType.Date)]
        public DateTime InspectionDate { get; set; } = DateTime.Today;

        public string? Notes { get; set; }
    }
}