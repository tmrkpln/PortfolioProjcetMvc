using Microsoft.AspNetCore.Mvc;

namespace CoreMvc_Project.ViewComponents.Dashboard
{
    public class AdminNotificationNavbarList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
