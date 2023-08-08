using Tour_Admin.Model;

namespace Tour_Admin.Interface
{
    public interface IAdmin
    {
        public Task<Admin> GetAdminByEmailAndPassword(string Admin_Email, string Admin_Password);

        string GenerateJwtToken(Admin admin);
    }
}
