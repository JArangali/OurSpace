using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace OurSpace.Models;
public class Accepted
{

        [Key]
        public int AId { get; set; }
        public string AName { get; set; }
        public string AEmail { get; set; }
        public DateOnly ADate { get; set; }
        public TimeOnly ATime { get; set; }
        public string ACNum { get; set; }
        public int APNum { get; set; }
        public string AMessage { get; set; }

}



