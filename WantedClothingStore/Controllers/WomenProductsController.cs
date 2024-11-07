using Microsoft.AspNetCore.Mvc;
using WantedClothingStore.Services;

namespace WantedClothingStore.Controllers
{
    public class WomenController : Controller
    {
        private readonly ProductService _productService;

        public WomenController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(string size)
        {
            var womenProducts = _productService.GetWomenProducts(size);
            return View(womenProducts);
        }
    }
}