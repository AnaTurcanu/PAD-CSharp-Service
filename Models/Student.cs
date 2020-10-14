using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Status { get; set; }
        public ICollection<Mark> Marks { get; set; } = new List<Mark>();

    }
}
