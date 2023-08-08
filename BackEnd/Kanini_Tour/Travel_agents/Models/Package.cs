using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tour_Package.Models;

namespace Tour_Package.Models
{
    public class Package
    {
        [Key]
        public int Package_Id { get; set; }

        public string? Package_Name { get; set; }

        public string? Package_Type { get; set; }

        public int? Package_Rate { get; set; }

        public string? Duration { get; set; }

        public string? Package_Itenary { get; set; }

        public string? Package_Food { get; set; }

        public string? Package_Hotel { get; set; }

        public string? Package_Image { get; set; }

        [ForeignKey("Locations")]
        public int Location_Id { get; set; }
        public Location? Locations { get; set;}

        [ForeignKey("Travel_agents")]

        public int Travelagent_Id { get; set; }

        public Travel_agent? Travel_agents { get; set;}

        public ICollection<Spots>? spots { get; set; }

    }
}
