using DataAccess.Repositories.Brands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SellStuff.Areas.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsRepository _brandsRepository;

        public BrandsController(IBrandsRepository brandsRepository)
        {
            _brandsRepository = brandsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandsRepository.GetBrands();

            return new JsonResult(brands);
        }

        [HttpGet("{brandId}")]
        public async Task<IActionResult> GetById([FromRoute] byte brandId)
        {
            var retrievedId = await _brandsRepository.GetBrandById(brandId);

            return new JsonResult(retrievedId);
        }
    }
}
