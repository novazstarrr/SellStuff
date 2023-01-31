using DataAccess.Repositories.Brands;
using DataAccess.Repositories.DeviceTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SellStuff.Areas.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceTypesController : ControllerBase
    {
        private readonly IDeviceTypesRepository _deviceTypesRepository;

        private readonly IBrandsRepository _brandsRepository;

        public DeviceTypesController(IDeviceTypesRepository deviceTypesRepository, IBrandsRepository brandsRepository)
        {
            _deviceTypesRepository = deviceTypesRepository;
            _brandsRepository = brandsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] byte? brandId/*, [FromQuery] string brandName*/)
        {
            var devices = await _deviceTypesRepository.GetAll(brandId/*, brandName*/);

            return new JsonResult(devices);
        }


        // /api/devicetypes/1 -- 1 = device type id
        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetDeviceById([FromRoute] byte deviceId)
        {
            var retrieveDeviceId = await _deviceTypesRepository.GetDeviceTypesById(deviceId);
            
            return new JsonResult(retrieveDeviceId);
        }

        //if getting multiple 
        //Remember this is wrong, but good practice. 
        [HttpGet("by-brand/{brandId}")]
        public async Task<IActionResult> GetDeviceTypesByBrandId([FromRoute] byte brandId)
        {
            var brand = await _brandsRepository.GetBrandById(brandId);
            
            if (brand == null) return NotFound($"Found no brand with id '{brandId}'");

            var deviceByBrand = await _deviceTypesRepository.GetDeviceTypesById(brandId);

            return new JsonResult(deviceByBrand);
        }
    }
}
