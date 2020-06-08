using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TokenJWTWebAPi.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Username is requerid.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is requerid.")]
        public string Password { get; set; }
    }
}
