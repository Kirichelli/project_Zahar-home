using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Storage.Entities
{
    public class UserRating
    {
        [Key]
        public int UserRating_Id { get; set; }
        public int User_Id { get; set; }
        [ForeignKey(nameof(User_Id))]
        public virtual User User { get; set; }
        public int Rating_Id { get; set; }
        [ForeignKey(nameof(Rating_Id))]
        public virtual Rating Rating { get; set; }
        public int Rating_Value { get; set; }


    }
}
