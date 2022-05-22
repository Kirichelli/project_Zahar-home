using Microsoft.EntityFrameworkCore;
using project_Zahar_home.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Storage
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<RecipeContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
