using BugFixer.Data.Context;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.Resume;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Data.Repository
{
    public class ResumeSkillsRepository : IResumeSkillsRepository
    {
        private readonly BugFixerDBContext _ctx;
        public ResumeSkillsRepository(BugFixerDBContext ctx)
        {
            _ctx = ctx;
        }
        public async Task AddResumeSkillsAsync(ResumeSkills skill)
        {
            await _ctx.ResumeSkills.AddAsync(skill);
        }

        public async Task<ResumeSkills> GetResumeSkillsByResumeIdAsync(int resumeId)
        {
            return await _ctx.ResumeSkills
                .FirstOrDefaultAsync(rs => rs.ResumeId == resumeId);
             
        }
        public async Task DeleteResumeSkillsAsync(ResumeSkills skills)
        {
            _ctx.ResumeSkills.Remove(skills);
        }

      
    }
}
