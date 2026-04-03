namespace InspectED.Models
{
    public class Grade
    {
        public int GradeId { get; set; }


        //Relationship with Device

        public ICollection<Device> Device { get; set; } = new List<Device>(); //Navigation property
    }
}
