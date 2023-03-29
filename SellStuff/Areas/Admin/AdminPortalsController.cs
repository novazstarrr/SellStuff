using DataAccess.Repositories.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace SellStuff.Areas.Admin
{
    public class AdminPortalsController : Controller
    {
        private readonly UserManager<User> _userManager;
        public AdminPortalsController(UserManager<User> userManager) 
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(this.User);
            string url = "/identity/account/login?returnUrl=" + "/bookings/create";

            if (user == null)
            {
                return Redirect(url);
            }

            string userId = user.Id;
            ViewBag.UserId = userId;

            return View();
        }
    }
}
