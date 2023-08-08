using Admins.Model;

namespace Admins.Interface
{
    public interface IAdminToken
    {
        Task<Admins> GetAdminByEmailAndPassword(string email, string password);
    }
}
