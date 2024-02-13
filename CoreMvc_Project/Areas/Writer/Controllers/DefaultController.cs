using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc_Project.Areas.Writer.Controllers
{
    [Area("Writer")]//Hangi areada çalıştığını belirtmemiz gerekiyor
    [Authorize] // Sayfaya yektilendirdiğimiz kişler dışında başka kimsenin girmemesini sağlar
    public class DefaultController : Controller
    {
        AnnounCementManager announCement = new AnnounCementManager(new EfAnnounCementDal());
        public IActionResult Index()
        {
            var values = announCement.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AnnounCementDetails(int id)
        {
            AnnounCement announcement = announCement.GetByID(id);
            return View(announcement);
        }
    }
}
