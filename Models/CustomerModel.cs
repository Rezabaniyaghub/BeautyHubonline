using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "نام و نام خانوادگی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string PhoneNumber { get; set; }

        [Display(Name = "زمان موجود")]
        public DateTime AvailableTime { get; set; }

        [Display(Name = "قرارهای رزرو شده")]
        public DateTime? BookedAppointment { get; set; }
    }
}


