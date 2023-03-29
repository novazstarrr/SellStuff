using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Bookings
{
    public class EditBookingRequest
    {
        public string BookingId { get; set; }
        public short Model { set; get; }
        public byte MemorySize { set; get; }
        public byte Grade { get; set; }
        public DateTime DateSelector { get; set; }
        public DateTime HourSelector { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
