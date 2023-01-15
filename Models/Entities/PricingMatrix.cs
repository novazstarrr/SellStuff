using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class PricingMatrix
    {
        [Key, Column(Order = 1)]
        public short ModelId { get; set; }

        public Model Model { get; set; }

        [Key, Column(Order = 2)]
        public byte MemorySizeId { get; set; }

        public MemorySize MemorySize { get; set; }

        [Key, Column(Order = 3)]
        public byte GradeId { get; set; }

        public Grade Grade { get; set; }

        public decimal Price { get; set; }
    }
}
