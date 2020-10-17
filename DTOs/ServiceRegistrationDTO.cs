using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.DTOs
{
    public class ServiceRegistrationDTO
    {
        public string Service_name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
    }
}
