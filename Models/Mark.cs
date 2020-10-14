using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Type { get; set; }
        public int AtestationNo { get; set; }
        public string Status { get; set; }
        public Student Student { get; set; }

    }
}
