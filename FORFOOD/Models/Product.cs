using System;
using System.Collections.Generic;

namespace FORFOOD.Models
{
    public partial class Products
    {
        public int IdProduct { get; set; } 
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
