using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DeviceRepository
    {
        private readonly IotHomeControlContext _dbContext;

        public DeviceRepository(IotHomeControlContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Device>> getAll()
        {
            return await _dbContext.Device.ToListAsync();
        }
    }
}