using BusinessLayer.Concrete;
using CoreMvc_Project.Models;
using DataAccessLayer.ConCrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc_Project.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {

            var values = messageManager.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}
