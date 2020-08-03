using SimpleAuthAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleAuthAPI
{
    public class Busline
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        public ICollection<Path> Paths { get; set; }
    }
}
