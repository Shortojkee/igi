using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Введите, пожалуйста, имя")]
        [Display(Name = "Имя пользователя")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите, пожалуйста, e-mail")]
        [Display(Name = "Адрес электронной почты")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                        ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите адрес")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите почтовый индекс")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите страну")]
        public string Country { get; set; }
    }

}
