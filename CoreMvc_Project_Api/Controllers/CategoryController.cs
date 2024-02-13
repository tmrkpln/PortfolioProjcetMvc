using CoreMvc_Project_Api.DAL.ApiContext;
using CoreMvc_Project_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreMvc_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]

        public IActionResult CategoryGet(int id)
        {
           using var c = new Context();
            var value = c.Categories.Find(id);
            if(value == null) {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("",p);//Geriye Oluşturuldu Methodu Döndür (Başarılı 201)
        }
        [HttpDelete]

        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var v = c.Categories.Find(id);
            if(v == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(v);
                c.SaveChanges();
                return NoContent();//İçerik Olmadan Döndür
            }
        }
        [HttpPut]

        public IActionResult CategoryUpdate(Category p)
        {
            using var c = new Context();
            var v = c.Find<Category>(p.CategoryID);
            if(v == null)
            {
                return NotFound();
            }
            else
            {
                v.CategoryName = p.CategoryName;
                c.Update(v);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
