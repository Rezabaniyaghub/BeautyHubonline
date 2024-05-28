using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    //خدمات مشتری
    public class CustomerServiceEntity
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string HairstylistId { get; set; }
        public string ShortnessOfHair { get; set; }
        public string HairShaping { get; set; }
        public string ShavingBeard { get; set; }
        public string GroomMakeUp { get; set; }


        public virtual CustomerEntity CustomerEntity { get; set; }
        public virtual HairstylistEntity HairstylistEntity { get; set; }

        public CustomerServiceEntity()
        {

        }
    }
}
