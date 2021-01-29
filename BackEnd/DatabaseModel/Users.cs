using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class Users
    {
        public Users()
        {
            ResearchOwners = new HashSet<ResearchOwners>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PermissionLevel { get; set; }

        public virtual PermissionLevels PermissionLevelNavigation { get; set; }
        public virtual ICollection<ResearchOwners> ResearchOwners { get; set; }
    }
}
