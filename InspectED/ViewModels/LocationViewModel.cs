using System.ComponentModel.DataAnnotations;

namespace InspectED.ViewModels
{
    public class LocationViewModel
    {
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Location name is required.")]
        [Display(Name = "Location")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}