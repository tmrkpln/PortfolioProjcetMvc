using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreMvc_Project.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceID)
        {
            var v = experienceManager.GetByID(ExperienceID);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }
        public IActionResult DeleteExperience(int ExperienceID)
        {
            var v = experienceManager.GetByID(ExperienceID);
            experienceManager.TDelete(v);
            return NoContent();
                
        }
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);
        }
        [HttpPost]
        public IActionResult UpdateExperience(Experience p)

        {

            var existingExperience = experienceManager.GetByID(p.ExperienceID);

            existingExperience.Name = p.Name;

            existingExperience.ImageUrl = p.ImageUrl;

            existingExperience.Date = p.Date;

            existingExperience.Description = p.Description;



            experienceManager.TUpdate(existingExperience);



            var updatedValues = JsonConvert.SerializeObject(existingExperience);

            return Json(updatedValues);

        }
    }
}