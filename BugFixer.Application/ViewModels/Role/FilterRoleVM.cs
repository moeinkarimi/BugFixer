using BugFixer.Application.ViewModels.Common;
using System.ComponentModel.DataAnnotations;
namespace BugFixer.Application.ViewModels.Role
{
    public class FilterRoleVM : BasePaging<Domain.Models.Role.Role>
    {
        [Display(Name = "عنوان نقش")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های {0}بیش از {1}کاراکتر است")]
        public string? Title { get; set; }

    }
}
