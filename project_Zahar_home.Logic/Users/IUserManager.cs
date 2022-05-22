using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Users
{
    public interface IUserManager
    {
        Task<IList<User>> GetAll();
        Task Add(User user);
        Task<User> getUser(string email);
        Task<User> getUserWithRole(string email, string password);
        Task Delete(int id);
    }
}
