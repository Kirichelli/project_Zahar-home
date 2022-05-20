using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Storage.Entities
{
     public class Ingridient
    {
        [Key]
        public int Ingridient_Id { get; set; }
        public string Ingridient_Name { get; set; }
    }
}
