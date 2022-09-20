using Microsoft.AspNetCore.Mvc;

namespace CleanArchProducts.Mvc.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        public ProductsController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}