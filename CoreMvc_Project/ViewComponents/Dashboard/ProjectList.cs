using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc_Project.ViewComponents.Dashboard
{
    public class ProjectList : ViewComponent
    {
        PortfolioManager p = new PortfolioManager(new EfProtfolioDal());

        public IViewComponentResult Invoke()
        {
            var values = p.TGetList();
            return View(values);
        }    
    }
}
