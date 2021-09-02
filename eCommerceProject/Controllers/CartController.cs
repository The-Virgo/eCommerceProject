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
        public async Task<IActionResult> Add(int id, string previousUrl)
        {
            Product p = await ProductDb.GetProductAsync(_context, id);

            CookieHelper.AddProductToCart(_httpContext, p);

            TempData["Message"] = p.Title + " added to cart";

            // Redirect back to previous page
            return Redirect(previousUrl);
        }

        public IActionResult Summary()
        {

            return View(CookieHelper.GetCartProducts(_httpContext));
        }
    }
}
