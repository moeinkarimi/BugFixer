using BugFixer.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace BugFixer.Domain.Models.Role
{
    public class Role : BaseEntity
    {

        [Display(Name = "عنوان نقش")]
        [Required]
        [MaxLength(200)]

        public string Title { get; set; }
        [Display(Name = "نام نقش")]
        [Required]
        [MaxLength()]

        public string Name { get; set; }



        #region Relations
        public List<RolePermission>? RolePermissions { get; set; }
        public List<User.User>? Users { get; set; }
        #endregion
    }
}
