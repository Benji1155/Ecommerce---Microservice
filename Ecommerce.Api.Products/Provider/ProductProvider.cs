using AutoMapper;
using Ecommerce.Api.Products.DB;
using Ecommerce.Api.Products.Interface;
using Ecommerce.Api.Products.Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Products.Provider
{
    public class ProductProvider : IProductProvider
    {
        private readonly ProductDBContext dbContext;
        private readonly IMapper mapper;

        public ProductProvider(ProductDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            PopulateDatabase();
        }
        void PopulateDatabase()
        {
            if (!dbContext.ProductHandler.Any())
            {
                dbContext.ProductHandler.Add(new ProductEntity { Id = 1, Name = "Spoon", Price = 4, Inventory = 0 });
                dbContext.ProductHandler.Add(new ProductEntity { Id = 2, Name = "Fork", Price = 2, Inventory = 2 });
                dbContext.ProductHandler.Add(new ProductEntity { Id = 3, Name = "Knife", Price = 52, Inventory = 23 });
                dbContext.ProductHandler.Add(new ProductEntity { Id = 4, Name = "Cup", Price = 1, Inventory = 511 });

                dbContext.SaveChanges();
            }
        }

        public Task GetProductAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<(bool IsSuccess, ProductModel product, string errorMessage)> GetProductAysnc(int id)
        {
            try
            {
                var product = await dbContext.ProductHandler.FirstOrDefaultAsync(items => items.Id == id);
                if (product != null)
                {
                    var result = mapper.Map<ProductEntity, ProductModel>(product);
                    return (true, result, null);
                }
                else
                {
                    return (false, null, "Not Found");
                }
            }
            catch (Exception e)
            {
                return (false, null, e.Message);
            }
        }

        public Task<(bool IsSuccess, ProductModel product, string errorMessage)> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<(bool IsSuccess, IEnumerable<ProductModel> product, string errorMessage)> IProductProvider.GetProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}