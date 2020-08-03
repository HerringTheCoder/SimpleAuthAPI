using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleAuthAPI.Models
{
    public class Path
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int BuslineId { get; set; }
       
        public Busline Busline { get; set; }

        public ICollection<Course> Courses { get; set; }

        public IList<PathStation> PathStations { get; set; }

    }
}
