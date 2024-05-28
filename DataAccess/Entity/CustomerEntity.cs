using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    //مشتری
    public class CustomerEntity
    {

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime AvailableTime { get; set; }
        public DateTime? BookedAppointment { get; set; }


        public virtual List<CustomerServiceEntity> CustomerServiceEntity { get; set; }
        public virtual List<GivingTimeEntity> GivingTimeEntity { get; set; }
        public virtual AppointmentEntity AppointmentEntity { get; set; }

        public CustomerEntity()
        {
        }
    }

}
