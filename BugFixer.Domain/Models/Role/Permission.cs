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
        [MaxLength(50)]
        public string Title { get; set; }


        #region Relations
        public List<RolePermission>? RolePermissions { get; set; }
        #endregion

    }
}
