using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        public void Save();
        public void Add(User entity);
        public User GetByEmail(string email);
    }
}
