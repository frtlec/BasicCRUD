using BasicCRUD.Business.Abstract;
using BasicCRUD.Business.Utilities.Mapping.AutoMapper;
using BasicCRUD.Core.Utilities.Results;
using BasicCRUD.DataAccess.Abstract;
using BasicCRUD.Entities.Concrete.DataModels;
using BasicCRUD.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public async Task<Response<NoContent>> Add(ProductAddDto productDto)
        {
            try
            {
                var product = ObjectMapper.Mapper.Map<Product>(productDto);
                await _productDal.Add(product);
                return  Response<NoContent>.Success(201);
            }
            catch (Exception ex)
            {
                return Response<NoContent>.Fail(ex.Message,500);
            }
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            try
            {
                var product = await _productDal.Get(p=>p.ProductId==id);
                await _productDal.Delete(product);
                return Response<NoContent>.Success(204);
            }
            catch (Exception ex)
            {
                return Response<NoContent>.Fail(ex.Message, 500);
            }
        }

        public async Task<Response<List<GetAllProductDto>>> GetAllProducts()
        {
            try
            {
                var result= await _productDal.GetList();
                var products = ObjectMapper.Mapper.Map<List<GetAllProductDto>>(result);
                return Response<List<GetAllProductDto>>.Success(products, 200);
            }
            catch (Exception ex)
            {
                return Response<List<GetAllProductDto>>.Fail(ex.Message, 500);
            }
        }

        public async Task<Response<List<GetAllProductDto>>> GetAllProductsById(int id)
        {
            try
            {
                var result = await _productDal.GetList(p=>p.ProductId==id);
                var products = ObjectMapper.Mapper.Map<List<GetAllProductDto>>(result);
                return Response<List<GetAllProductDto>>.Success(products, 200);
            }
            catch (Exception ex)
            {
                return Response<List<GetAllProductDto>>.Fail(ex.Message, 500);
            }
        }

        public async Task<Response<NoContent>> Update(ProductUpdateDto productDto)
        {
            try
            {
                var product = ObjectMapper.Mapper.Map<Product>(productDto);
                await _productDal.Update(product);
                return Response<NoContent>.Success(204);
            }
            catch (Exception ex)
            {
                return Response<NoContent>.Fail(ex.Message, 500);
            }
        }

    }
}
