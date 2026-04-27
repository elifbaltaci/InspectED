using System.ComponentModel.DataAnnotations;

namespace InspectED.Models
{
    public class Location
    {
        internal int LocationId;

        public int Id { get; set; }

        [Required(ErrorMessage = "Location name is required.")]
        [Display(Name = "Location Name")]
        public string Name { get; set; }

       
        public string? Description { get; set; }
    }
}