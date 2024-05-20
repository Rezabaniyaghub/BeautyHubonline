using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
              //زمان دادن به مشتری
    public class GivingTimeEntity
    {
        public int GivingTimeId { get; set; }

        public int CustomerId { get; set; }

        public virtual CustomerEntity Customer { get; set; }
        public virtual HairstylistEntity HairstylistEntity { get; set; }

        public GivingTimeEntity()
        {
            
        }

    }

}
