using System;
using System.Collections.Generic;

namespace FORFOOD.Models
{
    public partial class Purchases
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public string? Products { get; set; }
        public double? Total { get; set; }
        public int? IdUser { get; set; }

        public virtual User? IdUserNavigation { get; set; }
    }
}
