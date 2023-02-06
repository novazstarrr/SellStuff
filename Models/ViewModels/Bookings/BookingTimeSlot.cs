namespace Models.ViewModels
{
    public class BookingTimeSlot
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool IsAvailable { get; set; }
    }
}