using System.Threading.Tasks;
using api.Exceptions;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository
    {
        private readonly IotHomeControlContext _dbContext;

        public UserRepository(IotHomeControlContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> findByEmail(string email)
        {
            User user = await _dbContext.User
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) {
                throw (new UserNotFoundException());
            }

            return user;
        }
    }
}