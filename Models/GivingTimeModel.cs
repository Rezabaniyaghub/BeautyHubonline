using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GivingTimeModel
    {
        [Key]
        [Display(Name = "زمان دادن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int GivingTimeId { get; set; }

        public int CustomerId { get; set; }
    }
}
