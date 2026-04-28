using System.ComponentModel.DataAnnotations;

namespace InspectED.Models
{
    public class Location
    {
        public int LocationId { get; set; }  

        [Required(ErrorMessage = "Location name is required.")]
        [Display(Name = "Location Name")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<Device>? Devices { get; set; }
    }
}