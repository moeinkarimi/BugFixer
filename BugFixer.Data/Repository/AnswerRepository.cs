using BugFixer.Data.Context;
using BugFixer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Data.Repository
{
    public class AnswerRepository:IAnswerRepository
    {
        private readonly BugFixerDBContext _ctx;

        public AnswerRepository(BugFixerDBContext ctx)
        {
            _ctx = ctx;
        }


    }
}
