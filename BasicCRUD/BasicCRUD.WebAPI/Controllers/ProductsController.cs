using BasicCRUD.Business.Abstract;
using BasicCRUD.Business.Utilities.Logger;
using BasicCRUD.Business.Utilities.Logger.Enums;
using BasicCRUD.Business.Utilities.Logger.Models;
using BasicCRUD.Entities.Concrete.DataModels;
using BasicCRUD.Entities.Concrete.Dtos;
using BasicCRUD.WebAPI.Controllers.BasesController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasicCRUD.WebAPI.Controllers
{
    //-api/products/getall
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : CustomBaseController
    {
        private readonly IProductService _productService;
        private readonly ILoggerManager _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductsController(IProductService productService, ILoggerManager logger, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           
            var result = await _productService.GetAllProducts();
            return CreateActionResultInstance(result);
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
