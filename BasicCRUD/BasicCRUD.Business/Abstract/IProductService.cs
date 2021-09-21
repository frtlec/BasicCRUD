using BasicCRUD.Core.Utilities.Results;
using BasicCRUD.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.Business.Abstract
{
    public interface IProductService
    {
        Task<Response<List<GetAllProductDto>>> GetAllProducts();
        Task<Response<List<GetAllProductDto>>> GetAllProductsById(int id);
        Task<Response<NoContent>> Update(ProductUpdateDto productDto);
        Task<Response<NoContent>> Add(ProductAddDto productDto);
        Task<Response<NoContent>> Delete(int id);
    }
}
