﻿using BugFixer.Domain.Models.Base;
using BugFixer.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Models.Resume
{
    public class Resume : BaseEntity
    {
        public string ProfessionName { get; set; }
        public int? WorkExperienceYears { get; set; }
        public string? Skills { get; set; }
        public string? EducationalDocuments { get; set; }
        public string? Favourites { get; set; }
        public string? Bio { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int UserId { get; set; }

        #region Relatio
        [ForeignKey("UserId")]
        public User.User User { get; set; }
        #endregion

    }
}
