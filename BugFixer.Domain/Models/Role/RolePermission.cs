using BugFixer.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Models.Role
{
    public class RolePermission:BaseEntity
    {
        public int RoleId { get; set; }
        public int PersmissionId { get; set; }

        #region Relations
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
        [ForeignKey("PersmissionId")]
        public Permission? Permission { get; set; }
        #endregion
    }
}
