using Microsoft.AspNetCore.Mvc;

namespace CoreMvc_Project.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
