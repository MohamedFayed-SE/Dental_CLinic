using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental_CLinic.BLL.ViewModels
{
    public class RegistrationVM
    {
        [Required(ErrorMessage ="This Field is Required")]
        [StringLength(30,ErrorMessage ="Max Length IS 30 FOr This Filed")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
      [StringLength(30,ErrorMessage ="Max Length IS 30 FOr This Filed")]    
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "This Field is Required")]
        [EmailAddress(ErrorMessage ="This Emial is In Valid")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(30, ErrorMessage = "Max Length IS 30 FOr This Filed")]
        public string Password { get; set; }
        
        [Required(ErrorMessage ="This Field is Required")]
        [StringLength(30, ErrorMessage = "Max Length IS 30 FOr This Filed")]
        [Compare("Password",ErrorMessage ="The Password DOesnt Match")]
        public string ConfirmedPassword { get; set; }

        public bool IsAgree { get; set; }


    }
}
