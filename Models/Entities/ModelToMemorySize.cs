using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [PrimaryKey(nameof(ModelId), (nameof(MemorySizeId)))]
    public class ModelToMemorySize
    {
        public short ModelId { get; set; }

        public Model Model { get; set; }

        public byte MemorySizeId { get; set; }

        public MemorySize MemorySize { get; set; }

        

        
    }
}
