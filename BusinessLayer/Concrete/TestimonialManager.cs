using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        ItestimonialDal _tesimonialDal;

        public TestimonialManager(ItestimonialDal tesimonialDal)
        {
            _tesimonialDal = tesimonialDal;
        }

        public Testimonial GetByID(int id)
        {
            return _tesimonialDal.GetByID(id);
        }

        public void TAdd(Testimonial t)
        {
            _tesimonialDal.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
             _tesimonialDal.Delete(t);
        }

        public List<Testimonial> TGetList()
        {
            return _tesimonialDal.GetList();
        }

        public List<Testimonial> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Testimonial t)
        {
           _tesimonialDal.Update(t);
        }
    }
}
