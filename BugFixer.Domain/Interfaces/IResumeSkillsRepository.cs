using BugFixer.Domain.Models.Resume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Interfaces
{
    public interface IResumeSkillsRepository
    {
        Task AddResumeSkillsAsync(ResumeSkills skills);
        Task<ResumeSkills> GetResumeSkillsByResumeIdAsync(int resumeId);
        Task DeleteResumeSkillsAsync(ResumeSkills skills);
    }
}
