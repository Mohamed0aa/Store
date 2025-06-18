using AutoMapper;
using Domain.Contract;
using Domain.Models;
using Services.Abstraction;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService(IUnitOfWork unitOfWork,IMapper _mapper) : IProductService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public  async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products =await  _unitOfWork.GetRepo<Product, int>().GetAllAsync();

            var result =  _mapper.Map<IEnumerable<ProductDto>>(products);

            return result;
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var products = await _unitOfWork.GetRepo<ProductBrand, int>().GetAllAsync();

            var result = _mapper.Map<IEnumerable<BrandDto>>(products);

            return result;
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var products = await _unitOfWork.GetRepo<ProductType, int>().GetAllAsync();

            var result = _mapper.Map<IEnumerable<TypeDto>>(products);

            return result;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.GetRepo<Product, int>().GetByIdAsync(id);

            var result = _mapper.Map<ProductDto>(product);

            return result;
        }
    }
}
