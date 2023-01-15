using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public short ModelId { get; set; }

        public Model Model { get; set; }

        public byte MemorySizeId { get; set; }

        public MemorySize MemorySize { get; set; }

        public byte GradeId { get; set; }

        public Grade Grade { get; set; }

        public DateTime TimeSlot { get; set; }
    }
}
