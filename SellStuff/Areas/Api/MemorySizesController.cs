using DataAccess.Repositories.MemorySizes;
using Microsoft.AspNetCore.Mvc;

namespace SellStuff.Areas.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class MemorySizesController : ControllerBase
	{
		private IMemorySizesRepository _memorySizesRepository;

		public MemorySizesController(IMemorySizesRepository memorySizesRepository)
		{
			_memorySizesRepository = memorySizesRepository;

		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var memorySizes = await _memorySizesRepository.GetAll();

			return new JsonResult(memorySizes);
		}

		[HttpGet("{memorySizeId}")]
		public async Task<IActionResult> GetMemorySizesById([FromRoute] byte memorySizeId)
		{
			var retriedMemorySize = await _memorySizesRepository.GetMemorySizeById(memorySizeId);

			return new JsonResult(retriedMemorySize);
		}
	}
}
