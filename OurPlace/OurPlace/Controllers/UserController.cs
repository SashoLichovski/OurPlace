using Microsoft.AspNetCore.Mvc;

namespace OurPlace.Controllers
{
    public class UserController : Controller
    {
        public IActionResult MyProfile()
        {
            return View();
        }
    }
}
