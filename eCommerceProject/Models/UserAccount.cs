﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceProject.Models
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }

        [Compare(nameof(Email))]
        [Required]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(120, MinimumLength = 6, ErrorMessage = "Password must be between {2} and {1} characters")]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
       
        [DataType(DataType.Date)] // Time is ignored
        public DateTime? DateOfBirth { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string UsernameOrEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
