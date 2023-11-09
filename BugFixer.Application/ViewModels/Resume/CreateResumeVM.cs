using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Resume
{
    public class CreateResumeVM: BaseVM.BaseVM
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [StringLength(100, ErrorMessage ="{0} نمی تواند بیشتر از 100 حرف باشد.")]
        public string ProfessionName { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [StringLength(100, ErrorMessage = "{0} نمی تواند بیشتر از 100 حرف باشد.")]
        public int? WorkExperienceYears { get; set; }
        [Display(Name = "نام کاربری")]
    
        [StringLength(100, ErrorMessage = "{0} نمی تواند بیشتر از 100 حرف باشد.")]
        public string? EducationalDocuments { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        public string? Favourites { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        public string? Bio { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int UserId { get; set; }
    }
}
