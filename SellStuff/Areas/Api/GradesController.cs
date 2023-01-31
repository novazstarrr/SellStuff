using Microsoft.AspNetCore.Mvc;
using DataAccess.Repositories.Grades.Grades;

namespace SellStuff.Areas.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class GradesController : ControllerBase
	{
		private readonly IGradesRepository _gradesRepository;

		public GradesController(IGradesRepository gradesRepository)
		{
			_gradesRepository = gradesRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var grades = await _gradesRepository.GetAll();

			return new JsonResult(grades);
		}

		[HttpGet("{gradeId}")]
		public async Task<IActionResult> GetGradeById([FromRoute] byte gradeId)
		{
			var retrieveGradeId = await _gradesRepository.GetGradeById(gradeId);

			return new JsonResult(retrieveGradeId);
		}
	}
}
