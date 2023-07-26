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
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public void Add(Role t)
        {
            _roleDal.Insert(t);
        }

        public void Delete(Role t)
        {
            _roleDal.Delete(t);
        }

        public Role GetById(int id)
        {
            return _roleDal.GetById(id);
        }

        public List<Role> GetList()
        {
            return _roleDal.GetListAll();
        }

        public void Update(Role t)
        {
            _roleDal.Update(t);
        }
    }
}
