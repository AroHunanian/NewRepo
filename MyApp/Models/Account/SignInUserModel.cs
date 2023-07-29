using Microsoft.AspNetCore.Identity;
using MyApp.Data;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.Account
{
    public class SignInUserModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
