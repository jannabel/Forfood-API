using System;
using System.Collections.Generic;

namespace FORFOOD.Models
{
    public partial class UsersView
    {
        public int? IdUser { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Rol { get; set; }
    }
}
