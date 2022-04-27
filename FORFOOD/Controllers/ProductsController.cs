using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FORFOOD.Data;
using FORFOOD.Models;
using FORFOOD.Services.Implements;
using FORFOOD.Repositories.Implements;

namespace FORFOOD.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductsService productService = new ProductsService(new ProductsRepository(new ForfoodContext()));

        public ProductsController()
        {

        }

        [HttpGet("GetProducts")]
        public async Task<JsonResult> GetProducts()
        {
            return Json(await productService.GetAll());
        }

        [HttpPost("CreateProducts")]
        public async Task<JsonResult> CreateProducts(Products product)
        {
            return Json(await productService.Insert(product));
        }

        [HttpDelete("DeleteProducts")]
        public async Task DeleteProducts(int product)
        {
            await productService.Delete(product);
        }

        [HttpPut("UpdateProducts")]
        public async Task UpdateProducts(Products product)
        {
            await productService.Update(product);
        }


        [HttpGet("GetByCode")]
        public async Task GetByCode(Products product)
        {
            await productService.GetById(product.IdProduct);
        }

    }
}
