using Microsoft.AspNetCore.Mvc;
using WantedClothingStore.Models;
using WantedClothingStore.Services;
using System.Linq;

namespace WantedClothingStore.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly ProductService _productService;

        public CartController(CartService cartService, ProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        public IActionResult Index()
{
    var cartItems = _cartService.GetCartItems();
    var totalPrice = cartItems.Sum(item => item.Price); // Calculate total price in the controller
    ViewBag.TotalPrice = totalPrice; // Pass the total price to the view using ViewBag
    return View(cartItems);
}

        public IActionResult AddToCart(int productId, string category)
        {
            ProductBase product = null;

            if (category == "Men")
            {
                product = _productService.GetMenProducts().FirstOrDefault(p => p.Id == productId);
            }
            else if (category == "Women")
            {
                product = _productService.GetWomenProducts().FirstOrDefault(p => p.Id == productId);
            }

            if (product != null)
            {
                _cartService.AddToCart(product);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            _cartService.RemoveFromCart(productId);
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            _cartService.ClearCart();
            return RedirectToAction("Index");
        }
    }
}