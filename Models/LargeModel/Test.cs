using System.ComponentModel.DataAnnotations;

namespace SimpleAuthAPI.Models.LargeModel
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public string Test11 { get; set; }

        public string Test111 { get; set; }

        public string Test22 { get; set; }

        public string Test222 { get; set; }
    }
}
