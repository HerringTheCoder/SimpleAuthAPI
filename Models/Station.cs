using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleAuthAPI.Models
{
    public class Station
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Point Point { get; set; }

        public IList<PathStation> PathStations { get; set; }
    }
}
