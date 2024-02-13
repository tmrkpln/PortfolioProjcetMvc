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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            this.experienceDal = experienceDal;
        }

        public Experience GetByID(int id)
        {
            return experienceDal.GetByID(id);
        }

        public void TAdd(Experience t)
        {
            experienceDal.Insert(t);
        }

        public void TDelete(Experience t)
        {
            experienceDal.Delete(t);    
        }

        public List<Experience> TGetList()
        {
            return experienceDal.GetList();
        }

        public List<Experience> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Experience t)
        {
            experienceDal.Update(t);
        }
    }
}
