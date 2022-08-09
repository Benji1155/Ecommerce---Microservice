using Ecommerce.Api.Products.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Api.Products.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        public IProductProvider productProvider { get; }
        public ProductController(IProductProvider productProvider)
        {
            this.productProvider = productProvider;
        }

        public IProductProvider GetProductProvider()
        {
            return productProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync()
        {
            var result = await productProvider.GetProductAsync();
            if (result.IsSuccess)
            {
                return Ok(result.product);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult NotFoundResult()
        {
            throw new NotImplementedException();
        }
    }
}
