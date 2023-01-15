using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal abstract class BaseRepository
    {
        protected ApplicationDbContext Context { get; set; }

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
