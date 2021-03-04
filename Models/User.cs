using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChessWithCohorts.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}

        [Required(ErrorMessage="First name is required.")]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters in length.")]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}

        [Required(ErrorMessage="Last name is required.")]
        [MinLength(2, ErrorMessage="Last name must be at least 2 characters in length.")]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}

        [Required(ErrorMessage="Email address is required.")]
        [EmailAddress]
        public string Email {get; set;}

        [Required(ErrorMessage="Password is required.")]
        [Compare("ConfirmPassword", ErrorMessage="Passwords do not match. Please try again.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters in length.")]
        public string Password {get; set;}

        [NotMapped]
        [Required(ErrorMessage="You must confirm password.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters in length.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword {get; set;}

        // Navigational Properties
        // public List<Wedding> MyWeddings {get; set;}
        // public List<Rsvp> MyRsvps {get; set;}

        public string Fullname()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}