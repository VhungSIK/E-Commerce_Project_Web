using Microsoft.AspNetCore.Mvc;

namespace fbwa_web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}