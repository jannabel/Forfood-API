using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FORFOOD.Models;
using FORFOOD.Repositories;
using FORFOOD.Repositories.Implements;


namespace FORFOOD.Services.Implements
{
    public class PurchasesService : GenericService<Purchases>, IPurchasesRepository
    {
        public PurchasesService(IPurchasesRepository purchasesRepository) : base(purchasesRepository)
        {
        }
    }
}
