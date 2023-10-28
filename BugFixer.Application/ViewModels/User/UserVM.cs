using BugFixer.Domain.Models.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.User
{
    public class UserVM: BaseVM.BaseVM
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
        public Role? Role { get; set; }
        #endregion
    }
}
