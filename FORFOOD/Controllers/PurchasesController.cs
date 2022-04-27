using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FORFOOD.Data;
using FORFOOD.Models;
using FORFOOD.Services.Implements;
using FORFOOD.Repositories.Implements;

namespace FORFOOD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : Controller
    {
        //Esto crea una nueva instancia de un PurchasesService
        private readonly PurchasesService purchaseService = new PurchasesService(new PurchasesRepository(new ForfoodContext()));

        //Este método registra una nueva compra
        [HttpPost("Create")]
        public async Task<JsonResult> CreatePurchases(Purchases purchases)
        {
            return Json(await purchaseService.Insert(purchases));
        }

        //Este método obtiene todas las compras realizadas por los usuarios
        [HttpGet("Get")]
        public async Task<JsonResult> GetPurchases()
        {
            return Json(await purchaseService.GetAll());
        }

        //Este método actualiza una compra
        [HttpPut("Update")]
        public async Task<JsonResult> UpdatePurchases(Purchases purchases)
        {
            return Json(await purchaseService.Update(purchases));
        }

        //Este método elimina una compra
        [HttpDelete("Delete")]
        public async Task DeletePurchases(int id)
        {
            await purchaseService.Delete(id);
        }

        

       
    }
}
