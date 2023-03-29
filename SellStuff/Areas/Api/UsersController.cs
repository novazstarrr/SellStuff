using DataAccess.Repositories.Users;
using Microsoft.AspNetCore.Mvc;

namespace SellStuff.Areas.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] string userId)
        {
            var retrieveUserId = await _userRepository.GetUserByUserId(userId);

            return new JsonResult(retrieveUserId);
        }
    }
}
