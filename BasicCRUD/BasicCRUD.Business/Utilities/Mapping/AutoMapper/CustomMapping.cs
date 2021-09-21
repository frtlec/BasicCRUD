using AutoMapper;
using BasicCRUD.Entities.Concrete.DataModels;
using BasicCRUD.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.Business.Utilities.Mapping.AutoMapper
{
    public class CustomMapping:Profile
    {
        public CustomMapping()
        {
            CreateMap<Product, GetAllProductDto>().ReverseMap();
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<List<Product>, List<ProductAddDto>>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
        }
    }
}
