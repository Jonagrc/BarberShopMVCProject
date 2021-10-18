using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BarberShop.ViewModel

{//this is used for a LOGIN VIEW JUST LIKE REGISTER VIEW specific to a view
    public class LoginViewModel
    {//for login view we need 3 field that will go to the data base 
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Please Enter Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; } //boolean value we will set in login view
    }
}