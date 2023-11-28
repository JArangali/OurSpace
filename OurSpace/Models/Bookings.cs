using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace OurSpace.Models;
    public class Bookings
    {
    [Key]
        public int BId { get; set; }
        public string BName { get; set; }
        public string BEmail { get; set; }
        public DateOnly BDate { get; set; }
        public TimeOnly BTime { get; set; }
        public string BCNum { get; set; }
        public int BPNum { get; set; }
        public string BMessage { get; set; }
    }

