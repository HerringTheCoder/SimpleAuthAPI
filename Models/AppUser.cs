using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleAuthAPI.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [JsonIgnore]
        [DefaultValue(true)]
        public bool Active { get; set; }
    }
}
