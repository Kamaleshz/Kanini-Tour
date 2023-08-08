using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_Package.Models
{
    public class Location
    {
        [Key]
        public int Location_Id { get; set; }

        public string? Location_Name { get; set;}

        public string? Location_Image { get; set; }

        public ICollection<Package>? packages { get; set; }

    }
}
