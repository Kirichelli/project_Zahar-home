using project_Zahar_home.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Logic.Users
{
    public class UserManager : IUserManager
    {
        private readonly RecipeContext _recipeContext;
        
     

        public UserManager(RecipeContext context)
            {
                _recipeContext = context;
            }

        public void ChangePhoto(string path, string FileName, string email)
        {
            var user = _recipeContext.Users.FirstOrDefault(u => u.Email.Equals(email));
            if (user != null)
            {
                user.Path = path;
                user.FileName = FileName;
                _recipeContext.SaveChanges();
            }
        }

        public void Add(User user)
        {
            Role userRole = _recipeContext.Roles.FirstOrDefault(r => r.Name == "user");
            if (userRole != null)
                user.Role = userRole;
            _recipeContext.Users.Add(user);
            _recipeContext.SaveChanges();
        }

        public void ChangeNick(string nick, string email)
        {
            var userWithNick = _recipeContext.Users.FirstOrDefault(u => u.UserName.Equals(nick));
            var user = _recipeContext.Users.FirstOrDefault(u => u.Email.Equals(email));
            if (userWithNick == null)
            {
                user.UserName = nick;
                _recipeContext.SaveChanges();
            } 
        }

        public void Delete(int id)
        {
            var user = _recipeContext.Users.FirstOrDefault(u => u.User_Id == id);
            if (user != null)
            {
                _recipeContext.Users.Remove(user);
                _recipeContext.SaveChanges();
            }
        }

        public IList<User> GetAll() => _recipeContext.Users.Where(u => !u.Email.Equals("admin")).ToList();

        public User getUser(string email, string userName) => _recipeContext.Users.FirstOrDefault(u => u.Email.Equals(email) || u.UserName.Equals(userName));

        public User getUserWithRole(string email, string password) => _recipeContext.Users.Include(u => u.Role).FirstOrDefault(u => (u.Email.Equals(email) || u.UserName.Equals(email)) && u.Password.Equals(password));
    }
}
