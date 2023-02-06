using DataAccess.Repositories.ModelsToMemorySizes;
using Microsoft.AspNetCore.Mvc;

namespace SellStuff.Areas.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ModelsToMemorySizeController : ControllerBase
	{
		private readonly IModelsToMemorySizesRepostiory _modelsToMemorySizesRepostiory;

		public ModelsToMemorySizeController(IModelsToMemorySizesRepostiory modelsToMemorySizesRepostiory)
		{
			_modelsToMemorySizesRepostiory = modelsToMemorySizesRepostiory;
		}

		[HttpGet] 
		public async Task<IActionResult> GetAll([FromQuery] short? modelId)
		{
			var modelsToMemories = await _modelsToMemorySizesRepostiory.GetAll(modelId);

			return new JsonResult(modelsToMemories);
		}

		//[HttpGet]
		//public async Task<IActionResult> GetInfoFromModel([FromQuery] short modelId)
		//{
		//	var retrieveModelId = await _modelsToMemorySizesRepostiory.GetAllMemoryIdsFromModelIds(modelId);

		//	return new JsonResult(retrieveModelId);
		//}

	}
}
