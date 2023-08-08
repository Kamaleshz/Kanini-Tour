using System.ComponentModel.DataAnnotations;

namespace Tour_Admin.Model
{
    public class Admin
    {
        [Key]
        public int Admin_id { get; set; }
        public string? Admin_Name { get; set; }
        public string? Admin_Email { get; set; }
        public string? Admin_Password { get; set; }
    }
}
