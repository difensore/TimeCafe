using System.ComponentModel.DataAnnotations;

namespace TimeCafe.DAL.Models.ViewModels
{
    public class RegisterViewModel
    {
        /// <summary>
        /// Gets and sets email
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        /// <summary>
        /// Gets and sets password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Password should be minimum 6 and maximum 50 symbols.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        /// <summary>
        /// Gets and sets password confirmation
        /// </summary>
        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string? PasswordConfirmation { get; set; }
    }
}
