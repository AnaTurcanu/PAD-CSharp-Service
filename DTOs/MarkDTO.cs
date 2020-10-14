using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.DTOs
{
    public class MarkDTO
    {
        public int Value { get; set; }
        public string Type { get; set; }
        public int AtestationNo { get; set; }
        public string Status { get; set; }
        public int StudentId { get; set; }
    }
}
