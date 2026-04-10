using System;
using System.ComponentModel.DataAnnotations;

namespace InspectED.Models
{
    public class DeviceViewModel
    {
        [Display(Name = "Asset Tag")]
        public string AssetTag { get; set; } = string.Empty;

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        [EmailAddress]
        [Display(Name = "Assigned User Email")]
        public string AssignedUserEmail { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string ScreenCondition { get; set; } = string.Empty;

        public string KeyboardCondition { get; set; } = string.Empty;

        public string BatteryCondition { get; set; } = string.Empty;

        public bool ChargerAvailable { get; set; }

        public bool WifiWorking { get; set; }

        public bool TestingReady { get; set; }

        [DataType(DataType.Date)]
        public DateTime? InspectionDate { get; set; }

        public string Notes { get; set; } = string.Empty;
    }
}