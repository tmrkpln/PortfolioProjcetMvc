using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreMvc_Project.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
       
        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com";
            var values = _writerMessageManager.GetListReceiverMessage(p).OrderByDescending(x => x.WriterMessageID).Take(3).ToList(); //OrderByDescending z-a ' ya sıralar // Take(3) son 3 taneyi al
            return View(values);
        }
    }
}
