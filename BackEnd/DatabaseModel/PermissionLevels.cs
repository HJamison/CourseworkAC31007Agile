using System;
using System.Collections.Generic;

namespace CourseworkAC31007Agile.BackEnd.DatabaseModel
{
    public partial class PermissionLevels
    {
        public PermissionLevels()
        {
            Users = new HashSet<Users>();
        }

        public string Title { get; set; }
        public bool CanAssignPr { get; set; }
        public bool CanManageUsers { get; set; }
        public bool CanAssignCr { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
