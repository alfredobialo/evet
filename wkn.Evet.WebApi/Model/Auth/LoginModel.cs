using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace wkn.Evet.WebApi.Model.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage= "{0} is required for authentication")]
        [Description("Unique Identifier for a user")]
        [Display(Name = "User Id", Prompt = "User id Field")]
        [MinLength(5)]
        public string UserId { get; set; }
        
        [Required(ErrorMessage = "{0} is required"), MinLength(5), Display(Name = "Password Field")]
        public string Password { get; set; }
        
        public bool RememberPassword { get; set; }
        
    }
}