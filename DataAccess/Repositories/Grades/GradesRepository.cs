using DataAccess.Repositories.Grades.Grades;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Grades
{
	internal class GradesRepository : BaseRepository, IGradesRepository
	{
		public GradesRepository(ApplicationDbContext context) : base(context)
		{
		}
		
		public async Task<IEnumerable<Grade>> GetAll()
		{
			return await Context.Grades
				.AsNoTracking()
				.OrderByDescending(x => x.Name)
				.ToListAsync();


		}
		
		public async Task<Grade?> GetGradeById(byte gradeId)
		{
			return await Context.Grades
				.AsNoTracking()
				.FirstOrDefaultAsync(grade => grade.Id == gradeId);
		}
	}
}
