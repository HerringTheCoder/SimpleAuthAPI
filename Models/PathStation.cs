using System.ComponentModel.DataAnnotations;

namespace SimpleAuthAPI.Models
{
    public class PathStation
    {
        [Required]
        public int PathId { get; set; }
        public Path Path { get; set; }

        [Required]
        public int StationId { get; set; }
        public Station Station { get; set; }
    }
}
