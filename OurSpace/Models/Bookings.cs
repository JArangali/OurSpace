using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace OurSpace.Models;
    [Keyless]
    public class Bookings
    {
        public int BId { get; set; }
        public string BName { get; set; }
        public string BEmail { get; set; }
        public DateOnly BDate { get; set; }
        public TimeOnly BTime { get; set; }
        public string BCNum { get; set; }
        public int BPNum { get; set; }
        public string BMessage { get; set; }
    }

