using System.ComponentModel.DataAnnotations;

namespace Sevdah.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Korisničko ime je obavezno")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password je obavezan")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool zapamtiPass { get; set; }
    }
}
