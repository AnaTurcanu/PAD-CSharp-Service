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
    public class MarkController : ControllerBase
    {
        private readonly UniversityContext universityContext;
        public MarkController(UniversityContext universityContext)
        {
            this.universityContext = universityContext;
        }

        [HttpPost]

        public IActionResult PostMark([FromBody] MarkDTO markDTO)
        {
            var student = universityContext.Students.FirstOrDefault(s => s.Id == markDTO.StudentId);
            var mark = new Mark
            {
                Value = markDTO.Value,
                Status = "building",
                Student = student

            };
            // student.Marks.Add(mark);
            var createdMark = universityContext.Marks.Add(mark);
            universityContext.SaveChanges();

            return Ok(new { Id = createdMark.Entity.Id, Status = createdMark.Entity.Status });
        }



        [HttpPut("{markId}")]
        public IActionResult PutMark(int markId, [FromBody] MarkDTO markDTO)
        {
            var mark = universityContext.Marks.FirstOrDefault(s => s.Id == markId);
            mark.Type = markDTO.Type;
            mark.AtestationNo = markDTO.AtestationNo;
            universityContext.Entry(mark).State = EntityState.Modified;
            universityContext.SaveChanges();


            return Ok(new { Id = mark.Id, Status = mark.Status });

        }

        [HttpPut("{markId}/finalize")]
        public IActionResult PutMarkFinalize(int markId)
        {
            var mark = universityContext.Marks.FirstOrDefault(s => s.Id == markId);
            mark.Status = "processing";
            universityContext.Entry(mark).State = EntityState.Modified;
            universityContext.SaveChanges();


            return Ok(new { Id = mark.Id, Status = mark.Status });

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var mark = universityContext.Marks.FirstOrDefault(s => s.Id == id);
            mark.Status = "done";
            universityContext.Entry(mark).State = EntityState.Modified;
            universityContext.SaveChanges();


            return Ok(new { Id = mark.Id, Status = mark.Status, Result = new { Value = mark.Value, Type = mark.Type, AtestationNo = mark.AtestationNo } });
        }
    }

}
