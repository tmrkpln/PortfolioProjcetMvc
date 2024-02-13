using Microsoft.AspNetCore.Mvc;

namespace CoreMvc_Project.ViewComponents.Dashboard
{
    public class VisitorMap : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
