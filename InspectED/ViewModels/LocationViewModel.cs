using InspectED.Models;
using System.ComponentModel.DataAnnotations;

namespace InspectED.ViewModels
{
    public class LocationViewModel
    {
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Location name is required.")]
        public string Name { get; set; } = string.Empty;
    }
}