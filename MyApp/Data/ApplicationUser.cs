using Microsoft.AspNetCore.Identity;

namespace MyApp.Data
{
    public class ApplicationUser:IdentityUser
    {
        public override string? UserName { get => base.UserName; set => base.UserName = value; }
        public DateTime? DateOfBirth { get; set; }
    }
}
