using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Migrations;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnounCementManager : IAnnounCementService
    {
        IAnnounCementDal announCementDal;

        public AnnounCementManager(IAnnounCementDal announCementDal)
        {
            this.announCementDal = announCementDal;
        }

        public AnnounCement GetByID(int id)
        {
            return announCementDal.GetByID(id);
        }

        public void TAdd(AnnounCement t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AnnounCement t)
        {
            throw new NotImplementedException();
        }

        public List<AnnounCement> TGetList()
        {
            return announCementDal.GetList();
        }

        public List<AnnounCement> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AnnounCement t)
        {
            throw new NotImplementedException();
        }
    }
}
