using BugFixer.Application.ViewModels.Resume;
using BugFixer.Domain.Models.Resume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.Services.Interfaces
{
    public interface IResumeService
    {
        Task CreateResumeServiceAsync(CreateResumeVM resume);
    }
}
