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
    public class UsersService : GenericService<User>, IUsersService
    {
        public UsersService(IUsersRepository userrepository) : base(userrepository)
        {
        }
    }
}
