using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.ViewModel
{
    public class RegisterViewModel:LoginViewModel
    {
        [Required(ErrorMessage ="Please Enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


    }
}
