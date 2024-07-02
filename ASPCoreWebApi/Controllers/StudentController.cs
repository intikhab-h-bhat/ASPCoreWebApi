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



        public static List<Student> students = new List<Student>()
        {
              
                new Student
                {
                    Id = 1,
                    Name = "Student 1",
                    Address = "Address 1",
                    Email = "Abc@gmail.com"
                },
                new Student
                {
                    Id = 2,
                    Name = "Student 2",
                    Address = "Address 2",
                    Email = "Abc2@gmail.com"
                }

        };

        [HttpGet]
        public List<Student> getstudents()
        {
            return students;

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

        [HttpGet("{id:int}")]
        public Student getallstudent(int id) {
        
            return students.FirstOrDefault(x=> x.Id==id);
        
        }


    }
}
