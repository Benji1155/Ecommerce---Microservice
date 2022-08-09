using Ecommerce.Api.Products.Interface;
using Ecommerce.Api.Products.Provider;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Products
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductProvider, ProductProvider>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<DB.ProductDBContext>(options =>
            {
                options.UseInMemoryDatabase("ProductDB");
            });
            services.AddControllers();
        }
    }
}
