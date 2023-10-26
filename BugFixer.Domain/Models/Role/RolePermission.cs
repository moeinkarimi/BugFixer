using BugFixer.Domain.Models.Base;
using System;
using System.Collections.Generic;
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
        public Role? Role { get; set; }
        public Permission? Permission { get; set; }
        #endregion
    }
}
