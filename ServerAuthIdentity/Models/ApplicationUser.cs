using Microsoft.AspNetCore.Identity;

namespace ServerAuth.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
