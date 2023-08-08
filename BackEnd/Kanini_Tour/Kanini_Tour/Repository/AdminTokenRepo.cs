using Admins.Interface;
using Admins.Model;
using static Admins.Repository.AdminTokenRepo;

namespace Admins.Repository
{
    public class AdminTokenRepo
    {
        public class AdminRepo : IAdminToken
        {
            private readonly Admins _context;

            public AdminRepo(AdminContext context)
            {
                _context = context;
            }

            public async Task<Model.Admins> GetAdminByEmailAndPassword(string email, string password)
            {
                return await _context.Admins.FirstOrDefaultAsync(x => x.Admin_Email == email && x.Admin_Password == password);
            }
        }
    }
}
