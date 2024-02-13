using DataAccessLayer.ConCrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace CoreMvc_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DasboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DasboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;

            //Weather Api

            string api = "3134a859614fd380445cbb8d9458d23f";
            string connetion = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connetion); // connectiondan gelen değeri yükle
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //                              temperature gelen 0. değerin valuesini getirsin

            //Statictic
            Context c = new Context();
            ViewBag.v1 = c.writerMessages.Where(x => x.Receiver == values.Email).Count();
            ViewBag.v2 = c.announCements.Count();
            ViewBag.v3 = c.Users.Count();
            ViewBag.v4 = c.Skills.Count();
            return View();
        }
    }
}
/* https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=3134a859614fd380445cbb8d9458d23f */