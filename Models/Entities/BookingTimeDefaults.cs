namespace Models.Entities
{
	public class BookingTimeDefaults
	{
        public int Id { get; set; }

        public byte MinBookingTimeSlotFromNowInHours { get; set; }

		public short MaxBookingTimeSlotFromNowInHours { get; set; }

		public byte BookingIntervalInMinutes { get; set; }

		public DateTime StartOfDay { get; set; }

		public DateTime EndOfDay { get; set; }

		public bool CanWorkMonday { get; set; }

		public bool CanWorkTuesday { get; set; }

		public bool CanWorkWednesday { get; set; }

		public bool CanWorkThursday { get; set; }

		public bool CanWorkFriday { get; set; }

		public bool CanWorkSaturday { get; set; }

		public bool CanWorkSunday { get; set; }
	}
}