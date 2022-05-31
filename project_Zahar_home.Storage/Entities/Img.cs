using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Storage.Entities
{
    public  class Img
    {
        [Key]
        public int Img_Id { get; set; }
        public int Dish_Id { get; set; }
        [ForeignKey(nameof(Dish_Id))]
        public virtual Dish Dish { get; set; }
        public string Vid { get; set; }
        public string Url { get; set; }
    }
}
