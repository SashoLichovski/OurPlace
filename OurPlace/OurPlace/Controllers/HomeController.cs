using LazZiya.ImageResize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Services.DtoModels;
using System.Drawing;

namespace OurPlace.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult ActionResponse(Response response)
        {
            return View(response);
        }
    }
}
