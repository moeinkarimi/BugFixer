using System.ComponentModel.DataAnnotations;

namespace BugFixer.Application.ViewModels.User
{
    public class UserVM : BaseVM.BaseVM
    {
        [Required]
        [MaxLength(20)]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Mobile { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Password { get; set; }

        [Display(Name = "آواتار")]
        [Required]
        [MaxLength(50)]
        public string? Avatar { get; set; }
        public bool EmailConfirm { get; set; }

        public string? ActiveCode { get; set; }

        #region Relations
        public Domain.Models.Role.Role? Role { get; set; }
        #endregion
    }
}
