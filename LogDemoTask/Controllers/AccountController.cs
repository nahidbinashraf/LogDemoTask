using Microsoft.AspNetCore.Mvc;
using LogDemoTask.Models;

namespace LogDemoTask.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private static List<User> dummyUsers = new List<User>()
            {
                new User{ LoginId= 101},
                new User{ LoginId= 102},
                new User{ LoginId= 103},
            };

        [HttpPost]
        public IActionResult Login(User user)
        {
            return Ok(user);
        }

        [HttpGet]
        public IActionResult ListUser()
        {
            return Ok(dummyUsers);
        }

        [HttpPut]
        public IActionResult UpdateUser(int id)
        {
            return Ok(dummyUsers.FirstOrDefault(x => x.LoginId == id));
        }
    }
}
