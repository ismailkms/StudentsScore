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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User t)
        {
            _userDal.Insert(t);
        }

        public void Delete(User t)
        {
            _userDal.Delete(t);
        }

        public User GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> GetList()
        {
            return _userDal.GetListAll();
        }

        public void Update(User t)
        {
            _userDal.Update(t);
        }
        public User GetByUsernameAndPassword(string userName, string password)
        {
            return _userDal.GetByUsernameAndPassword(userName, password);
        }
    }
}
