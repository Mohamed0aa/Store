using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Abstraction
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>>GetAllProductsAsync();
        Task<ProductDto>GetByIdAsync(int id);
        Task<IEnumerable<BrandDto>>GetAllBrandsAsync();
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    }
}
