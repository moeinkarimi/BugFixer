using BugFixer.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Models.User
{
    public class Follower: BaseEntity
    {
        public int FollowedUserId { get; set; }
        public int FollowingUserId { get; set; }

        [ForeignKey("FollowingUserId")]
        public virtual User Users{ get; set; }

    }
}
