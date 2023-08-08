using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Package.Models
{
    public class Spots
    {
        [Key]
        public int Spot_Id { get; set; }

        public string? Spot_Name { get; set; }

        public string? Spot_Description { get; set; }

        public string? Spot_Image { get; set; }

        [ForeignKey("packages")]
        public int Package_Id { get; set; }
        public Package? packages { get; set; }
    }
}
