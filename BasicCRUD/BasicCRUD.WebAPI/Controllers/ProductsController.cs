using BasicCRUD.Business.Abstract;
using BasicCRUD.Entities.Concrete.Dtos;
using BasicCRUD.WebAPI.Controllers.BasesController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCRUD.WebAPI.Controllers
{
    //-api/products/getall
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResultInstance(await _productService.GetAllProducts());
        }
        [HttpPost]
        public async Task<IActionResult> New(ProductAddDto productAddDto)
        {
            return CreateActionResultInstance(await _productService.Add(productAddDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            return CreateActionResultInstance(await _productService.Update(productUpdateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResultInstance(await _productService.Delete(id));
        }
    }
}
