using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private IotHomeControlContext _iotHomeControlContext;
        public DeviceController(IotHomeControlContext iotHomeControlContext)
        {
            _iotHomeControlContext = iotHomeControlContext;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<Device> Get()
        {
            return _iotHomeControlContext.Device.ToList();
        }
    }
}
