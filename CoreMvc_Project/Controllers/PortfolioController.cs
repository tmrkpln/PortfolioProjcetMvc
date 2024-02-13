using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CoreMvc_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfProtfolioDal());
        public IActionResult Index()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }
        [HttpGet]

        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddPortfolio(Portfolio portfolio)
        {
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
        }
        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.GetByID(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            var values = portfolioManager.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);
            if(results.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");

            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
