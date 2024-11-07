using Microsoft.AspNetCore.Mvc;
using WantedClothingStore.Services;

namespace WantedClothingStore.Controllers
{
    public class MenController : Controller
    {
        private readonly ProductService _productService;

        // Инжектиране на ProductService в конструктора
        public MenController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            // Получаване на продуктите за мъже от продукта
            var menProducts = _productService.GetMenProducts();
            return View(menProducts);
        }
    }
}
