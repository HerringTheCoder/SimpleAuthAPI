using System.ComponentModel.DataAnnotations;

namespace SimpleAuthAPI.Requests
{
    public class RegisterRequest : LoginRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
