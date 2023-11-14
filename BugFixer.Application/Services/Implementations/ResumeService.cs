using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Resume;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.Resume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.Services.Implementations
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IResumeSkillsRepository _resumeSkillsRepository;
        public ResumeService(IResumeRepository resumeRepository, IResumeSkillsRepository resumeSkillsRepository)
        {
            _resumeRepository = resumeRepository;
            _resumeSkillsRepository = resumeSkillsRepository;

        }
        public async Task CreateResumeServiceAsync(CreateResumeVM resumeVm)
        {
            var resume = new Resume { 
                ProfessionName = resumeVm.ProfessionName,
                WorkExperienceYears = resumeVm.WorkExperienceYears,
                Bio=resumeVm.Bio,
                EducationalDocuments = resumeVm.EducationalDocuments,
                Favourites = resumeVm.Favourites,
                UserId = resumeVm.UserId,         
            };
            await _resumeRepository.CreateResumeAsync(resume);
            await _resumeRepository.SaveChangesAsync();

            if (resumeVm.ResumeSkills != null)
            {
                resumeVm.ResumeSkills.ForEach(async rs =>
                {
                    var resumeSkill = new ResumeSkills
                    {
                        SkillPercentage = rs.SkillPercentage,
                        SkillTitle = rs.SkillTitle,
                        ResumeId = resume.Id
                    };
                    await _resumeSkillsRepository.AddResumeSkillsAsync(resumeSkill);
                });
                await _resumeRepository.SaveChangesAsync();
            }

        }
    }
}
