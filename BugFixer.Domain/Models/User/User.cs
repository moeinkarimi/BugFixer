using BugFixer.Domain.Models.Base;
using BugFixer.Domain.Models.Questions;
using System.ComponentModel.DataAnnotations;

namespace BugFixer.Domain.Models.User
{
    public class User : BaseEntity
    {
        public  string? FirstName{ get; set; }
        public  string? LastName{ get; set; }
        [Required]
        [MaxLength(200)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        public string Mobile { get; set; }
        [Required]
        [MaxLength(60)]
        public string Password { get; set; }

        [Display(Name = "آواتار")]
        [Required]
        [MaxLength(500)]
        public string? Avatar { get; set; }
        [Display(Name = "کدفعالسازی")]
        [Required]
        [MaxLength(100)]
        public string? ActiveCode { get; set; }
        public string? AboutMe { get; set; }
        public bool EmailConfirm { get; set; }
        public int? RoleId { get; set; }


        #region Relations
        public Role.Role? Role { get; set; }
        public Resume.Resume? Resume { get; set; }
        public List<Follower>? FollowersOrFollowings { get; set; }
        public List<Question>? Questions { get; set; }
        public List<Answer>? Answers { get; set; }

        #endregion

    }
}
