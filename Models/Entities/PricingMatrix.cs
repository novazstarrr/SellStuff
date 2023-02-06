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
    [PrimaryKey(nameof(ModelId), nameof(MemorySizeId), nameof(GradeId))]
    public class PricingMatrix
    {
        public short ModelId { get; set; }

        public Model Model { get; set; }

        public byte MemorySizeId { get; set; }

        public MemorySize MemorySize { get; set; }

        public byte GradeId { get; set; }

        public Grade Grade { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
    }
}
