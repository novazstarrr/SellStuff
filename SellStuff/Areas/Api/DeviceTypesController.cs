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
        public async Task<IActionResult> Get([FromQuery] byte brandId)
        {
            var brand = await _brandsRepository.GetBrandById(brandId);
            if (brand == null) return NotFound($"Found no brand with id '{brandId}'");

            var deviceTypes = await _deviceTypesRepository.GetDeviceTypesByBrandId(brandId);

            return new JsonResult(deviceTypes);
        }
    }
}
