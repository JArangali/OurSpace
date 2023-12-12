using Microsoft.AspNetCore.Identity;

namespace OurSpace.Database
{
    public class UserIdentity : IdentityUser
    {
        public string? UFName { get; set; }
        public string? ULName { get; set;}
        public string? AdminCode { get; set; }



    }
}
