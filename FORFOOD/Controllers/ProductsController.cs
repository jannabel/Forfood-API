﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FORFOOD.Data;
using FORFOOD.Models;
using FORFOOD.Services.Implements;
using FORFOOD.Repositories.Implements;

namespace FORFOOD.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        //Instancia de un ProductService
        private readonly ProductsService productService = new ProductsService(new ProductsRepository(new ForfoodContext()));


        //Este método crea un nuevo producto
        [HttpPost("Create")]
        public async Task<JsonResult> CreateProducts(Products product)
        {
            return Json(await productService.Insert(product));
        }

        //Este método obtiene todos los productos registrados
        [HttpGet("Get")]
        public async Task<JsonResult> GetProducts()
        {
            return Json(await productService.GetAll());
        }

        //Este método actualiza un producto (Toma como referencia el ID)
        [HttpPut("Update")]
        public async Task<JsonResult> UpdateProducts(Products product)
        {
           return Json(await productService.Update(product));
        }

        //Este método elimina un producto a partir de un ID
        [HttpDelete("Delete")]
        public async Task DeleteProducts(int product)
        {
            await productService.Delete(product);
        }


    }
}
