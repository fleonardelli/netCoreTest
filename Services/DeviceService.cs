using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos.Device;
using api.Exceptions;
using api.Models;
using api.Repository;

namespace api.Services
{
    public class DeviceService
    {
        private readonly UserDeviceActionRepository _userDeviceActionRepository;
        private readonly UserService _userService;
        private readonly UserRoleRepository _userRoleRepository;
        private readonly DeviceRepository _deviceRepository;

        public DeviceService(
            UserDeviceActionRepository userDevicePermissionRepository,
            UserService userService,
            UserRoleRepository userRoleRepository,
            DeviceRepository deviceRepository
        )
        {
            _userDeviceActionRepository = userDevicePermissionRepository;
            _userService = userService;
            _userRoleRepository = userRoleRepository;
            _deviceRepository = deviceRepository;
        }

        public async Task<ServiceResponse<string>> executeDeviceAction(RequestDeviceAction requestDeviceAction)
        {
            ServiceResponse<string> serviceResponse = new ServiceResponse<string>();
            var userClaims = _userService.getAuthenticatedUserClaims();
            //Not sure if this big try block is  correct, declaring a variable inside a try block in PHP
            //doesn't limit its scope to the try block, so try blocks are smaller.
            try {
                var action = await _userDeviceActionRepository.getUserDeviceAction(
                    userClaims.Email,
                    requestDeviceAction.actionId,
                    requestDeviceAction.deviceId
                );

                Rol role = await _userRoleRepository.getUserRole(userClaims.Email);

                if (!role.isParent() &&  action.Name.Contains("REQUEST"))
                {
                    //here we should call a service that will send a notification to
                    //the main user email of the family (or push notification)
                    //asking for permission
                    serviceResponse.Message = "Action request sent";

                    return serviceResponse;
                }

                //here we call the service with the connection to the Transport Layer API,
                //and ask for the action to run.

                serviceResponse.Message = "Action performed";

            } catch (KeyNotFoundException) {
                //This will be returned even if the endpoint receives a device id incorrect,
                //we could split the queries to check if the device exists and return the correct
                //message. It will be less performant, but will give a better UX.
                //Anyways, the list of devices is gotten from the API, and FE should render it,
                //so we should never receive a request with an invalid deviceId.
                serviceResponse.Message = "Action forbbiden for user";
                serviceResponse.Success = false;
            } catch (UserRoleNotFoundException ex) {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Device>>> getAll()
        {
            ServiceResponse<List<Device>> serviceResponse = new ServiceResponse<List<Device>>();

            serviceResponse.Data = await _deviceRepository.getAll();

            return serviceResponse;
        }
    }
}