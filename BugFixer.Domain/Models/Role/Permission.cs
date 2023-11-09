using BugFixer.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Models.Role
{
    public class Permission : BaseEntity
    {
        [Display(Name = "عنوان دسترسی")]
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string PermissionName { get; set; }

        #region Relations
        public List<RolePermission>? RolePermissions { get; set; }
        #endregion

    }
}
