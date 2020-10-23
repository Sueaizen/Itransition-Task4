using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication15.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the WebApplication15User class
    public class WebApplication15User : IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastLogingTime { get; set; }
        public UserStatus Status { get; set; }
        //public bool IsCheked { get; set; }

        public static explicit operator WebApplication15User(Task<WebApplication15User> v)
        {
            throw new NotImplementedException();
        }
    }
    public enum UserStatus
    {
        Unblock,
        Block
    }
}
