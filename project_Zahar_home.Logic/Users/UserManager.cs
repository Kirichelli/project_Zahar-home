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

        public async Task Add(User user)
        {
            Role userRole = await _recipeContext.Roles.FirstOrDefaultAsync(r => r.Name == "user");
            if (userRole != null)
                user.Role = userRole;
            _recipeContext.Users.Add(user);
            await _recipeContext.SaveChangesAsync();
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

        public async Task Delete(int id)
        {
            var user = _recipeContext.Users.FirstOrDefault(u => u.User_Id == id);
            if (user != null)
            {
                _recipeContext.Users.Remove(user);
                await _recipeContext.SaveChangesAsync();
            }
        }

        public async Task<IList<User>> GetAll() => await _recipeContext.Users.Where(u => !u.Email.Equals("admin")).ToListAsync();

        public async Task<User> getUser(string email, string userName) => await _recipeContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email) || u.UserName.Equals(userName));

        public async Task<User> getUserWithRole(string email, string password) => await _recipeContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => (u.Email.Equals(email) || u.UserName.Equals(email)) && u.Password.Equals(password));
    }
}
