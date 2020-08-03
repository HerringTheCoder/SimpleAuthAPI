using System.ComponentModel.DataAnnotations;

namespace SimpleAuthAPI.Models
{
    public class Course
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PathId { get; set; }

        [Required]
        public int GroupId { get; set; }

        public Path Path { get; set; }

        public Group Group { get; set; }
    }
}
