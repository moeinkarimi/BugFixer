using System.ComponentModel.DataAnnotations;

namespace BugFixer.Application.ViewModels.Role
{
    public class RoleVM : BaseVM.BaseVM
    {

        [Display(Name = "عنوان نقش")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های {0}بیش از {1}کاراکتر است")]

        public string? Title { get; set; }




        #region Relations
        public List<Domain.Models.Role.RolePermission>? RolePermissions { get; set; }
        public List<Domain.Models.User.User>? Users { get; set; }
        #endregion
    }
}
