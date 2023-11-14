using BugFixer.Data.Context;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.Resume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Data.Repository
{
    public class ResumeRepository: IResumeRepository
    {
        private readonly BugFixerDBContext _ctx;
        public ResumeRepository(BugFixerDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateResumeAsync(Resume resume)
        {
            await _ctx.Resumes.AddAsync(resume);
        }

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
