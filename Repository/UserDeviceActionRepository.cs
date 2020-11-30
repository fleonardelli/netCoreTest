using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserDeviceActionRepository
    {
        private readonly IotHomeControlContext _dbContext;

        public UserDeviceActionRepository(IotHomeControlContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Permission> getUserDeviceAction(string userEmail, uint actionId, uint deviceId)
        {
            var action = await _dbContext.Permission
                .FromSqlInterpolated($@"SELECT p.*
                    FROM user u
                    INNER JOIN user_permission_device upd ON u.id = upd.user_id
                    INNER JOIN permission p on p.id = upd.permission_id
                    WHERE u.email = {userEmail} AND device_id = {deviceId} AND permission_id = {actionId}")
                .FirstOrDefaultAsync();

            if (action == null) {
                throw (new KeyNotFoundException());
            }

            return action;
        }
    }
}