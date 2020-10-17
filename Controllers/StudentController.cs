using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserMicroservice.DTOs;
using UserMicroservice.Models;

namespace UserMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly UniversityContext universityContext;
        public StudentController(UniversityContext universityContext)
        {
            this.universityContext = universityContext;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = universityContext.Students.FirstOrDefault(s => s.Id == id);
            student.Status = "done";
            universityContext.Entry(student).State = EntityState.Modified;
            universityContext.SaveChanges();


            return Ok(new { Id = student.Id, Status = student.Status, Result = new {Name = student.Name, Group = student.Group } });
        }

        // POST: api/User
        [HttpPost]
        
        public IActionResult Post([FromBody] string studentName)
        {
            var student = new Student {
                Name = studentName, 
                Status = "building"
            };

           var createdStudent = universityContext.Students.Add(student);
             universityContext.SaveChanges();

            return Ok(new { Id = createdStudent.Entity.Id, Status = createdStudent.Entity.Status });
        }

        [HttpPost("service-register")]

        public IActionResult ServiceRegister()
        {
            var service_name = "Service 1";
            var ip = HttpContext.Request.Host.Value;
            var type = "type 1";

            return Ok(value: new { Name = service_name, Ip = ip, Type = type});
        }

        [HttpPost("init-student")]

        public IActionResult InitStudent([FromBody] StudentCreationDTO studentDTO)
        {
            var student = new Student
            {
                Name = studentDTO.Name,
                Group = studentDTO.Group
            };

            var createdStudent = universityContext.Students.Add(student);
            universityContext.SaveChanges();

            return Ok(new { Status = "success", Message = $"Student {createdStudent.Entity.Name} registered." });
        }

        // POST: api/User
        [HttpPut("nota")]

        public IActionResult PutMark([FromBody] StudentUpdateDTO studentDTO)
        {
            var student = universityContext.Students.FirstOrDefault(s => s.Name == studentDTO.Name);
            var mark = new Mark
            {
                Value = studentDTO.Mark,
                Type = studentDTO.Type,
                AtestationNo = studentDTO.AtestationNo,
                Student = student

            };
            // student.Marks.Add(mark);
            var createdMark = universityContext.Marks.Add(mark);
            universityContext.SaveChanges();

            return Ok(new { Status = "Success", Message = $"Information on student {studentDTO.Name} was updated." });
        }

        [HttpGet("status")]
        public IActionResult GetStatus([FromQuery] string student)
        { 
           // var student = universityContext.Students.FirstOrDefault(s => s.Name == student);


            return Ok(new {Status = "processing" });
        }

        [HttpGet("nota-atestare")]
        public IActionResult GetMark([FromQuery] string student, [FromQuery] string type, [FromQuery] int atestationNo)
        {
            var stdMarks = universityContext.Students.Include(s => s.Marks).FirstOrDefault(s => s.Name == student).Marks.ToList();
            var stdMark = stdMarks.Where(s => s.Type == type && s.AtestationNo==atestationNo).FirstOrDefault();


            return Ok(new { Status = "success", Mark = stdMark.Value });
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string group)
        {
            var student = universityContext.Students.FirstOrDefault(s => s.Id == id);
            student.Group = group;
            universityContext.Entry(student).State = EntityState.Modified;
            universityContext.SaveChanges();


            return Ok(new { Id = student.Id, Status = student.Status });

        }

        [HttpPut("{id}/finalize")]
        public IActionResult Finalize(int id)
        {
            var student = universityContext.Students.FirstOrDefault(s => s.Id == id);
            student.Status = "processing";
            universityContext.Entry(student).State = EntityState.Modified;
            universityContext.SaveChanges();


            return Ok(new { Id = student.Id, Status = student.Status });

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
