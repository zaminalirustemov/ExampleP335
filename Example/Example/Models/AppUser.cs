using Microsoft.AspNetCore.Identity;

namespace Example.Models
{
    public class AppUser:IdentityUser
    {
        public string FavColor { get; set; }
    }
}
