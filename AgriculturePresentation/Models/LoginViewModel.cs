using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="Kullanıcı adınızı giriniz")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
