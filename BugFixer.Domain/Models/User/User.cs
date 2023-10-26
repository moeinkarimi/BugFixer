using BugFixer.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace BugFixer.Domain.Models.User
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Mobile { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Display(Name = "آواتار")]
        [Required]
        [MaxLength(50)]
        public string? Avatar { get; set; }
        [Display(Name = "کدفعالسازی")]
        [Required]
        [MaxLength(50)]
        public string? ActiveCode { get; set; }
        public bool EmailConfirm { get; set; }

        #region Relations
        public Role.Role? Role { get; set; }
        #endregion

    }
}
