using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CustomerServiceModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "کوتاهی مو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ShortnessOfHair { get; set; }

        [Display(Name = "فرم دادن به مو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string HairShaping { get; set; }

        [Display(Name = "اصلاح ریش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ShavingBeard { get; set; }

        [Display(Name = "گریم داماد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string GroomMakeUp { get; set; }
    }
}
