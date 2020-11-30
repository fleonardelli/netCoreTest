using System.Linq;
using System.Threading.Tasks;
using api.Exceptions;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRoleRepository
    {
        private readonly IotHomeControlContext _dbContext;

        public UserRoleRepository(IotHomeControlContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Rol> getUserRole(string userEmail)
        {
            var rol = await _dbContext.Rol
                .FromSqlInterpolated($@"SELECT r.*
                    FROM rol r
                    INNER JOIN user u ON u.rol_id = r.id
                    WHERE u.email = {userEmail}").FirstOrDefaultAsync();

            if (rol == null) {
                throw (new UserRoleNotFoundException($"User {userEmail} has no role set"));
            }

            return rol;
        }
    }
}