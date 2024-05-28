using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    //نوبت دهی
    public class AppointmentEntity
    {
        public int Id { get; set; }
        public string ServiceType { get; set; }
        public DateTime DateAndTimeOfAppointment { get; set; }
        public AppointmentStatus TurnStatus { get; set; }
        public decimal Price { get; set; }

        public int CustomerId { get; set; }

        public virtual CustomerEntity CustomerEntity { get; set; }


        public AppointmentEntity()
        {

        }
    }

    // تعریف enum برای وضعیت نوبت
    public enum AppointmentStatus
    {
        Available = 1, // در دسترس
        Reserved = 2 // رزرو شده
    }

}
