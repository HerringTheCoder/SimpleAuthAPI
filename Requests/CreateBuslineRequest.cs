using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthAPI.Requests
{
    public class CreateBuslineRequest
    {
        [Required]
        [StringLength(6)]  
        public string Number { get; set; }
    }
}
