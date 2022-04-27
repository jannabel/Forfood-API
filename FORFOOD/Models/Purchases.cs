using System;
using System.Collections.Generic;

namespace FORFOOD.Models
{
    public partial class Purchases
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public double? Total { get; set; }
        public int? IdUser { get; set; }
        public int? IdProduct { get; set; }
        public int? Cant { get; set; }

    }
}
