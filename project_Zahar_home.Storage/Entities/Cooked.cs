using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Storage.Entities;
public class Cooked
{
    [Key]
    public int Cooked_Id { get; set; }
/*    public int User_Id { get; set; }
    [ForeignKey(nameof(User_Id))]*/
/*    public virtual User User { get; set; }*/
    
    //public  int Favourite_Id { get; set; }
    //[ForeignKey(nameof(Favourite_Id))]
    //public virtual Favourite Favourite { get; set; }
    public int UserRating_Id { get; set; }
    [ForeignKey(nameof(UserRating_Id))]
    public virtual UserRating UserRating { get; set; }
}
