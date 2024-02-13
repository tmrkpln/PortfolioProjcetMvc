using CoreMvc_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreMvc_Project.Areas.Writer.Controllers
{
    [AllowAnonymous]

    [Area("Writer")]

    [Route("Writer/[controller]/[action]")]

   
    public class LoginController : Controller
    {
        private readonly SignInManager<WriterUser> _signInManager;

        public LoginController(SignInManager<WriterUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if(ModelState.IsValid)// UserLoginViewModel içindeki display/required koşulları sağlandıysa if ' e gir.
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName,p.Password,true,true);//Kullanıcı p. parametresinden gelen username password değerlerini kontrol ediyor.
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Profile");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Kullanıcı Adı veya Şifre");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
