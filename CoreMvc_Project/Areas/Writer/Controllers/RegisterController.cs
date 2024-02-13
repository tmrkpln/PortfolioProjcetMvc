using CoreMvc_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreMvc_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)//Model Geçerli ise
            {
                WriterUser w = new WriterUser()
                {
                    Name = p.Name,
                    Surname = p.SurName,
                    Email = p.Mail,
                    UserName = p.UserName,
                    ImageUrl = p.ImageUrl

                };
                if(p.ConfirmPassword == p.Password)
                {
                    var result = await _userManager.CreateAsync(w, p.Password);//Identity kütüphanseinin createasync methodunu hesap oluşturduğumuzda kullanıyoruz ve password bilgisini metota veriyoruz.
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            return View();
        }
    }
}
