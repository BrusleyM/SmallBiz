using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SmallBizAPI.Models
{
    public class User : IdentityUser
    {

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name can't be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name can't be longer than 50 characters.")]
        public string LastName { get; set; }
    }
}
