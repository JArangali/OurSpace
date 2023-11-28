namespace OurSpace.Models
{
    public class Bookings
    {
        public int AId { get; set; }
        public string BName { get; set; }
        public string BEmail { get; set; }
        public DateOnly BDate { get; set; }
        public TimeOnly BTime { get; set; }
        public int BCNum { get; set; }
        public int BPNum { get; set; }
        public string BMessage { get; set; }
    }
}
