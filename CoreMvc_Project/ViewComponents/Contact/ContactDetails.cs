using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace CoreMvc_Project.ViewComponents.Contact
{
    public class ContactDetails : ViewComponent
    {

        ContactManager contactManager = new ContactManager(new EfContactDal());

        public IViewComponentResult Invoke()
        {
            var value = contactManager.TGetList();
            return View(value);
        }
    }
}
