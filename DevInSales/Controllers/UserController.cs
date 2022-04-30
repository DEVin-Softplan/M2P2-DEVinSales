using DevInSales.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DevInSales.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public UserPostDTO Create([FromBody] UserPostDTO user)
        {
            return user;
        }
    }
}
