using AutoMapper;
using Domain.Models;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfile
{
    public  class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.BrandName, o => o.MapFrom(d => d.ProductBrand.Name))
                .ForMember(p => p.TypeName, o => o.MapFrom(d => d.ProductType.Name));
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();
        }
    }
}
