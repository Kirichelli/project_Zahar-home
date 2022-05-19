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
        private readonly RecipeContext _context;

        public UserManager(RecipeContext context)
        {
            _context = context;
        }
    
        public async Task Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.User_Id == id);
            if (user == null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<User>> GetAll() => await _context.Users.ToListAsync();
    }
}
