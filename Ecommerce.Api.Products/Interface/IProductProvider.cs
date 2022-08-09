using Ecommerce.Api.Products.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Products.Interface
{
    public interface IProductProvider
    {
        Task<(bool IsSuccess, IEnumerable<ProductModel> product, string errorMessage)> GetProductAsync();

        Task<(bool IsSuccess, ProductModel product, string errorMessage)> GetProductAsync(int id);
    }
}
