﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(EfSkillDal efSkillDal)
        {
            _skillDal = efSkillDal;
        }

        public Skill GetByID(int id)
        {
            return _skillDal.GetByID(id);
        }

        public void TAdd(Skill t)
        {
            _skillDal.Insert(t);
        }

        public void TDelete(Skill t)
        {
          _skillDal.Delete(t);
        }

        public List<Skill> TGetList()
        {
            return _skillDal.GetList();
        }

        public List<Skill> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Skill t)
        {
            _skillDal.Update(t);
        }
    }
}
