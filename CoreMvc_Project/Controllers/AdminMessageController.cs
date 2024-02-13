using BusinessLayer.Concrete;
using DataAccessLayer.ConCrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreMvc_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string p = "admin@gmail.com";
            var values = writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p = "admin@gmail.com";
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var values = writerMessageManager.GetByID(id);
            return View(values);
        }
        public IActionResult AdminMessageDelete(int id, string sourceView)
        {
            var values = writerMessageManager.GetByID(id);
            writerMessageManager.TDelete(values);

            if (sourceView == "SenderMessageList")
            {
                return RedirectToAction("SenderMessageList");
            }
            else if (sourceView == "ReceiverMessageList")
            {
                return RedirectToAction("ReceiverMessageList");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage messageManager)
        {
            messageManager.Sender = "admin@gmail.com";
            messageManager.SenderName = "Admin";
            messageManager.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == messageManager.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            messageManager.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(messageManager);
            return RedirectToAction("SenderMessageList");

        }
    }
}