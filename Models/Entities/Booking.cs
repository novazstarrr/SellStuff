using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public short ModelId { get; set; }

        public Model Model { get; set; }

        public byte MemorySizeId { get; set; }

        public MemorySize MemorySize { get; set; }

        public byte GradeId { get; set; }

        public Grade Grade { get; set; }

        public DateTime BookingDateTime { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsCancelled { get; set; }

    }
}
