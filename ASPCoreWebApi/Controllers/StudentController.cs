using ASPCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASPCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {



        //public static List<Student> students = new List<Student>()
        //{
              
        //        new Student
        //        {
        //            Id = 1,
        //            Name = "Student 1",
        //            Address = "Address 1",
        //            Email = "Abc@gmail.com"
        //        },
        //        new Student
        //        {
        //            Id = 2,
        //            Name = "Student 2",
        //            Address = "Address 2",
        //            Email = "Abc2@gmail.com"
        //        }

        //};

        [HttpGet]
        [Route("All",Name ="GetAllStudents")]
        public ActionResult<IEnumerable<Student>> Getstudents()
        {
            // return students;

            //OK -200 status
            return Ok(StudentRepository.students);

            //return new List<Student>
            //{
            //    new Student
            //    {
            //        Id = 1,
            //        Name = "Student 1",
            //        Address = "Address 1",
            //        Email = "Abc@gmail.com"
            //    },
            //    new Student
            //    {
            //        Id = 2,
            //        Name = "Student 2",
            //        Address = "Address 2",
            //        Email = "Abc2@gmail.com"
            //    }
            //};
        }

        [HttpGet]
        //[HttpGet("{id:int}")]
        [Route("{id:int}",Name = "GetStudentById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Student> GetstudentById(int id) {
        
            if (id <= 0)
            {
                // Badrequest -400 status
                return BadRequest("The id cannot be 0 or less than 0");
            }

            var student = StudentRepository.students.FirstOrDefault(x => x.Id == id);
            if (student == null)           
                // NotFound -404 status
                return NotFound($"The student id {id} you are looking doesnot exist");

            // Ok -200 status
            //return Ok(StudentRepository.students.FirstOrDefault(x=> x.Id==id));
            return Ok(student);
        }

        [HttpGet("{name:alpha}")]
        public ActionResult<Student> GetstudentByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var student=StudentRepository.students.FirstOrDefault(x=>x.Name == name);

            if (student == null)
            {
                // NotFound -404 status
                return NotFound("The Student Name does not exist");
            }

            // OK -200 status
            return Ok(student);

        }

        [HttpDelete("{id}")]

        public ActionResult DeleteStudent(int id)
        {
            if (id <= 0)
            {
                // Badrequest -400 status
                return BadRequest("The id cannot be 0 or less than 0");
            }
            var stu=StudentRepository.students.FirstOrDefault(x=> x.Id==id);
            if (stu == null)
                // NotFound -404 status
                return NotFound($"The student id {id} you are looking doesnot exist");

            StudentRepository.students.Remove(stu);
            return Ok($" {stu.Name} Student Deleted sucessfully");
        }
    }
}
