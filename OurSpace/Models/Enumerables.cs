namespace OurSpace.Models;
public class TwoModelViewModel
{
    public IEnumerable<Bookings> Bookings { get; set; }
    public IEnumerable<Bookings> Accepted { get; set; }
    public IEnumerable<Bookings> Completed { get; set; }
    public IEnumerable<Bookings> Archive { get; set; }
}