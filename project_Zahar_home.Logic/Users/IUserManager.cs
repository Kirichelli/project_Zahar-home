using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Users
{
    public interface IUserManager
    {
        IList<User> GetAll();
        void Add(User user);
        User getUser(string email, string userName);
        User getUserWithRole(string email, string password);
        void Delete(int id);
        void ChangeNick(string nick, string email);
    }
}
