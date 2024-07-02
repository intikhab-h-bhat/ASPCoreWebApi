
using Microsoft.AspNetCore.Mvc;
using ASPCoreWebApi.Models;
using System.Reflection;

namespace ASPCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>();
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User request)
        {
            if (users.Count != 0)
            {
                foreach (var user in users)
                {
                    if (user.Id == request.Id)
                    {
                        return BadRequest(user.Id + " already exist");
                    }
                    //else
                    //{
                    //    users.Add(request);
                     
                    //}
                }
                users.Add(request);
            }
            else
            {
                users.Add(request);
                
            }
            return Ok(users);


        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User request)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                //user.Id = id;
                user.Name = request.Name;
                user.Email = request.Email;
                user.Job = request.Job;
                return Ok(user);
            }
        }
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            users.Remove(user);
        }
    }
}
