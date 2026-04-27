using System.ComponentModel.DataAnnotations;

namespace InspectED.ViewModels
{
    public class LocationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Location name is required.")]
        [Display(Name = "Location Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}