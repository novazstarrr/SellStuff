using DataAccess.Repositories.DeviceTypes;
using DataAccess.Repositories.Models;
using Microsoft.AspNetCore.Mvc;

namespace SellStuff.Areas.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ModelsController : ControllerBase
	{
		private readonly IModelsRepository _modelRepository;
		private readonly IDeviceTypesRepository _deviceTypeRepository;

		public ModelsController(IModelsRepository modelRepository, IDeviceTypesRepository deviceTypesRepository)
		{
			_modelRepository = modelRepository;
			_deviceTypeRepository = deviceTypesRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] byte? deviceTypesId)
		{
			var models = await _modelRepository.GetAll(deviceTypesId);

			return new JsonResult(models);
		}

		[HttpGet("{modelId}")]
		public async Task<IActionResult> GetModelById([FromRoute] short modelId)
		{
			var retrieveModelId = await _modelRepository.GetModelById(modelId);

			return new JsonResult(retrieveModelId);
		}
	}
}
