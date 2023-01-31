using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Grades.Grades
{
    public interface IGradesRepository
	{
		Task<Grade?> GetGradeById(byte gradeId);

		Task<IEnumerable<Grade>> GetAll();
	}
}
