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
        private readonly UserContext _userContext;

        public UserManager(RecipeContext context, UserContext userContext)
        {
            _recipeContext = context;
            _userContext = userContext;
        }

        public async Task Add(User user)
        {
            Role userRole = await _userContext.Roles.FirstOrDefaultAsync(r => r.Name == "user");
            if (userRole != null)
                user.Role = userRole;
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = _userContext.Users.FirstOrDefault(u => u.User_Id == id);
            if (user == null)
            {
                _userContext.Users.Remove(user);
                await _recipeContext.SaveChangesAsync();
            }
        }

        public async Task<IList<User>> GetAll() => await _userContext.Users.ToListAsync();

        public async Task<User> getUser(string email) => await _userContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> getUserWithRole(string email, string password) => await _userContext.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}
