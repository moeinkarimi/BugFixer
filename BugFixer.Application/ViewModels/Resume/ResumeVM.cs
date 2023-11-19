using BugFixer.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Resume
{
    public class ResumeVM
    {
        public string? ProfessionName { get; set; }
        public string? WorkExperienceYears { get; set; }
        public string? EducationalDocuments { get; set; }
        public string? Bio { get; set; }

        public UserVM? User { get; set; }



    }
}
