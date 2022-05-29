using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Storage.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
/*        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }*/
    }
}
