using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Zahar_home.Storage.Entities
{
    public class Type_Of_Kitchen
    {
        [Key]
        public int Type_Id { get; set; }
        public int Ingridient_id { get; set; }
        public string Ingridient_Name { get; set; }

        [ForeignKey(nameof(Ingridient_id))]

        public virtual Ingridient Ingridient { get; set; }
        
    }
}
