using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.DTOs
{
    public class StudentUpdateDTO
    {
        public string Name { get; set; }
        public int Mark { get; set; }
        public string Type { get; set; }
        public int AtestationNo { get; set; }
    }
}
