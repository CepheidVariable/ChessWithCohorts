using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessWithCohorts.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage="Email address is required.")]
        [EmailAddress]
        [Display(Name = "Email")]
        [NotMapped]
        public string LoginEmail {get; set;}

        [Required(ErrorMessage="Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters in length.")]
        [Display(Name = "Password")]
        [NotMapped]
        public string LoginPassword {get; set;}
    }
}