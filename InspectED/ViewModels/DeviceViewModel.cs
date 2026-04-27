using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InspectED.ViewModels
{
    public class DeviceViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Asset Tag")]
        public string AssetTag { get; set; }

        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        public string Model { get; set; }

        [Display(Name = "Assigned User Email")]
        public string AssignedUserEmail { get; set; }

       
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        
        public List<SelectListItem>? Locations { get; set; }

    
        public string ScreenCondition { get; set; }
        public string KeyboardCondition { get; set; }
        public string BatteryCondition { get; set; }

        public bool ChargerAvailable { get; set; }
        public bool WifiWorking { get; set; }
        public bool TestingReady { get; set; }

        public DateTime InspectionDate { get; set; }

        public string Notes { get; set; }
    }
}