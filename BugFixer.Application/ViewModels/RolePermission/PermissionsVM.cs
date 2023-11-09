using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.RolePermission
{
    public class PermissionsVM : BaseVM.BaseVM
    {
        [Display(Name = "عنوان دسترسی")]
        [Required]
        [MaxLength(200)]
        public string? Title { get; set; }

    }
}
