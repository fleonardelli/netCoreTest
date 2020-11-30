using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using api.Dtos.Device;
using api.Services;
using System.Collections.Generic;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("device/")]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceService _deviceService;
        public DeviceController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [Authorize]
        [HttpPost]
        [Route("action")]
        public async Task<IActionResult> ExecuteAction(RequestDeviceAction requestDeviceAction)
        {
            ServiceResponse<string> response = await _deviceService.executeDeviceAction(requestDeviceAction);

            if (response.Success) {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            //This should be filtered by the devices active for a family,
            //but for testing purposes I'm just returning all of them.
            //should return a Dto containing the tables device and device_type.
            ServiceResponse<List<Device>> response = await _deviceService.getAll();

            return Ok(response);
        }
    }
}
