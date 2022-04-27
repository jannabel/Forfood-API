using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FORFOOD.Models;
using FORFOOD.Data;

namespace FORFOOD.Repositories.Implements
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        public ProductsRepository(ForfoodContext _context) : base(_context)
        {


        }
    }
}
