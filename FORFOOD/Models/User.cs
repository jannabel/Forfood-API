using System;
using System.Collections.Generic;

namespace FORFOOD.Models
{
    public partial class User
    {
        public User()
        {
            Purchases = new HashSet<Purchases>();
        }

        public int IdUser { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }

        public virtual Role RoleNavigation { get; set; } = null!;
        public virtual ICollection<Purchases> Purchases { get; set; }
    }
}
