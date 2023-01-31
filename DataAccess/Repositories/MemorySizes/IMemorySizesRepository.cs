using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.MemorySizes
{
    public interface IMemorySizesRepository
    {
        Task<MemorySize?> GetMemorySizeById(byte memorySizeId);

        Task<IEnumerable<MemorySize>> GetAll();
    }
}
