using eCommerceProject.Data;
using eCommerceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public CartController(ProductContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public async Task<IActionResult> Add(int id)
        {
            Product p = await ProductDb.GetProductAsync(_context, id);
            const string CartCookie = "CartCookie";

            // Get existing cart items
            string existingItems = _httpContext.HttpContext.Request.Cookies[CartCookie];


            List<Product> cartProducts = new List<Product>();
            if(existingItems != null)
            {
                cartProducts = 
                    JsonConvert.DeserializeObject<List<Product>>(existingItems);
            }

            // Add current product to existing cart
            cartProducts.Add(p);

            // Add product list to cart cookie
            string data = JsonConvert.SerializeObject(cartProducts);
            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddYears(1),
                Secure = true,
                IsEssential = true
            };

            _httpContext.HttpContext.Response.Cookies.Append(CartCookie, data, options);

            // Redirect back to previous page
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Summary()
        {
            // Display all products in shopping cart cookie

            return View();
        }
    }
}
