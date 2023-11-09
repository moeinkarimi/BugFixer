using BugFixer.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Models.Resume
{
    public class ResumeSkills:BaseEntity
    {
        public string SkillTitle { get; set; }
        public int SkillPercentage { get; set; }

        public int ResumeId { get; set; }

        #region Relations
        [ForeignKey("ResumeId")]
        public Resume Resume { get; set; }

        #endregion
    }
}
