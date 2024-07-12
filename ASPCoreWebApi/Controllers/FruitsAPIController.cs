//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ASPCoreWebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FruitsAPIController : ControllerBase
//    {

//        public List<string> fruits = new List<string>()
//        {
//            "Apple","Banana","Orange"
//        };

//        [HttpGet]
//        public List<string> GetFruits()
//        {
//            return fruits;
//        }

//        [HttpGet("id")]
//        public string GetFruitByIndex(int id)
//        {

//            return fruits[id];
//        }

//        [HttpPut("{index}")]
//        public IActionResult UpdateFruits(int index)
//        {

//            if (index < 0 || index >= fruits.Count)
//            {
//                return BadRequest("Invalid index.");
//            }
//            fruits[index] = "Water Mellon";
//            return Ok(fruits);
//        }

//        [HttpDelete("{index}")]
//        public IActionResult DeleteFruit(int index)
//        {

//            if (index < 0 || index >= fruits.Count)
//            {
//                return BadRequest("Invalid index.");
//            }
//            fruits.Remove("Apple");
//            return Ok(fruits);
//        }

//        [HttpPost]
//        public IActionResult AddFruit(string strFruit)
//        {

//           fruits.Add(strFruit);
//            return Ok(fruits);
//        }
//    }

//}


