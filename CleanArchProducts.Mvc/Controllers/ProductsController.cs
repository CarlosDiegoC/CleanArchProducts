using System.Threading.Tasks;
using CleanArchProducts.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchProducts.Mvc.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
           var products = await _productService.GetProducts();
            return View(products);
        }
    }
}