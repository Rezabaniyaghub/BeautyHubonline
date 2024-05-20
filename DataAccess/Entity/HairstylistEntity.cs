using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    //نام آرایشگرها و آدرس آنها
    public class HairstylistEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string HallName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        public List<CustomerServiceEntity> CustomerServiceEntitiy { get; set; }
        public virtual List<GivingTimeEntity> GivingTimeEntitiy { get; set; }
    }
}
