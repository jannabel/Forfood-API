using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FORFOOD.Data;
using FORFOOD.Services.Implements;
using FORFOOD.Repositories.Implements;
using FORFOOD.Models;

namespace FORFOOD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        //Esto crea una nueva instancia de un UserService
        private readonly UsersService usersService = new UsersService(new UsersRepository(new ForfoodContext()));

        //Este método crea un nuevo usuario.
        [HttpPost("Create")]
        public async Task<JsonResult> CreateUsers(User user)
        {
            return Json(await usersService.Insert(user));
        }

        //Este método obtiene todos los usuarios registrados.
        [HttpGet("Get")]
        public async Task<JsonResult> GetUsers()
        {
            return Json(await usersService.GetAll());
        }

        //Este método actualiza un usuario (Toma como referencia el ID)
        [HttpPut("Update")]
        public async Task<JsonResult> UpdateUsers(User users)
        {
            return Json(await usersService.Update(users));
        }

        //Este método elimina un usuario a partir de un ID
        [HttpDelete("Delete")]
        public async Task DeleteUsers(int id)
        {
            await usersService.Delete(id);
        }


    }
}
