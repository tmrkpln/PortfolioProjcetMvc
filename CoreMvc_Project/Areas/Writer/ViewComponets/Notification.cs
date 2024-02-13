using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreMvc_Project.Areas.Writer.ViewComponets
{
    public class Notification : ViewComponent
    {
        AnnounCementManager announCementManager = new AnnounCementManager(new EfAnnounCementDal());
        public IViewComponentResult Invoke() 
        {
            var values = announCementManager.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}
