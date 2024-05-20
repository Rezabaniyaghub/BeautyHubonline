using DataAccess.Entity;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AppointmentModell
    {
        public int Id { get; set; }

        [Display(Name = "خدمات مورد نیاز برای نوبت ")]
        public string ServiceType { get; set; }

        [Display(Name = "تاریخ و زمان نوبت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime DateAndTimeOfAppointment { get; set; }

        [Display(Name = "وضعیت نوبت ")]
        public AppointmentStatus TurnStatus { get; set; }

        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
    }
}
