using DataAccess.Migrations;
using DataAccess.Repositories.Grades.Grades;
using DataAccess.Repositories.MemorySizes;
using DataAccess.Repositories.Models;
using DataAccess.Repositories.PricingMatrixs;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.ViewModels.PricingMatrix;

namespace SellStuff.Areas.Api
{
	[Route("api/controller")]
	[ApiController]
	public class PricingMatrixController : ControllerBase
	{
		private readonly IPricingMatrixRepository _pricingMatrixRepository;
		private readonly IModelsRepository _modelsRepository;
		private readonly IMemorySizesRepository _memorySizesRepository;
		private readonly IGradesRepository _gradesRepository;
		public PricingMatrixController(IPricingMatrixRepository pricingMatrixRepository, IModelsRepository modelsRepository,
			IMemorySizesRepository memorySizesRepository, IGradesRepository gradesRepository)
		{
			_pricingMatrixRepository = pricingMatrixRepository;
			_modelsRepository = modelsRepository;
			_memorySizesRepository = memorySizesRepository;
			_gradesRepository = gradesRepository;	
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] PricingMatrixQuery query)
		{
			query.ModelId = null;

			if (query.ModelId.HasValue)
			{
				var model = await _modelsRepository.GetModelById(query.ModelId.Value);
				if (model == null) return NotFound($"Found no model with id'{query.ModelId.Value}'");
			}

			if (query.MemorySizeId.HasValue)
			{
				var memory = await _memorySizesRepository.GetMemorySizeById(query.MemorySizeId.Value);
				if (memory == null) return NotFound($"Found no memory with id'{query.MemorySizeId.Value}'");
			}

			if (query.GradeId.HasValue)
			{
				var grade = await _gradesRepository.GetGradeById(query.GradeId.Value);
				if (grade == null) return NotFound($"Found no grade with id'{query.GradeId.Value}'");
			}

			var prices = await _pricingMatrixRepository.GetAll(query);

			return new JsonResult(prices);
		}
	}
}
