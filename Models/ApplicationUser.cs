using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace Web_Template.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? Address { get; set; }
    }
}
