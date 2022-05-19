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
        Task Create(User user);
        Task Delete(int id);
    }
}
