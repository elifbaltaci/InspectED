using System.ComponentModel.DataAnnotations.Schema;

namespace InspectED.Models
{
    public class Device
    {
        public int DeviceId { get; set; }

        public int AssetID { get; set; }

        public int Model { get; set; }

        public string AssignedUserEmail { get; set; } = string.Empty;

        public int GradeLevel { get; set; }


        //Relationship with Grade 

        [ForeignKey("Grade")]

        public int GradeId { get; set; }  //Foreign key property

        public Grade? Grade { get; set; } //Navigation property

    }
}
