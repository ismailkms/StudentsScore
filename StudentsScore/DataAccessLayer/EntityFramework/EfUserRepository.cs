using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserRepository : GenericRepository<User>, IUserDal
    {
        public User GetByUsernameAndPassword(string userName, string password)
        {
            using (var c = new Context())
            {
                return c.Users.Include(y=>y.Role).FirstOrDefault(x => x.Username == userName && x.Password == password);
            }
        }
    }
}
