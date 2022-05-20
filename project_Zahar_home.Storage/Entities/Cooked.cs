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
    
    public  int User_Id { get; set; }
}
