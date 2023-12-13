using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace OurSpace.Models;
public class Bookings
{
    [Key]
    public int BId { get; set; }
    public string? BName { get; set; }
    public string? BEmail { get; set; }
    public string? BDate { get; set; }
    public string? BCNum { get; set; }
    public int? BPNum { get; set; }
    public string? BMessage { get; set; }
    public string? BStatus { get; set; }
    public string? BHub { get; set; }
}

