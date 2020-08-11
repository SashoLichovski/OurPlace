using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OurPlace.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Overview(string userId)
        {
            return View();
        }
    }
}
