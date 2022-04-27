using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FORFOOD.Models;
using FORFOOD.Data;

namespace FORFOOD.Repositories.Implements
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(ForfoodContext _context) : base(_context)
        {

        }
    }
}
