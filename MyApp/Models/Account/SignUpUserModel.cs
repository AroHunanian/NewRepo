using Microsoft.AspNetCore.Identity;
using MyApp.Data;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.Account
{
    public class SignUpUserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string State { get; set; }
    }
}
