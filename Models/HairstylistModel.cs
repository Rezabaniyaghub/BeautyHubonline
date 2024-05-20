using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HairstylistModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام و نام خانوادگی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string FullName { get; set; }

        [Display(Name = "نام آرایشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string HallName { get; set; }


        [Display(Name = "لطفا آدرس خود را وارد کنید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string Address { get; set; }


        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string PhoneNumber { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }
    }
}
