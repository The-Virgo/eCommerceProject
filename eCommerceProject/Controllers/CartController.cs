using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceProject.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Add(int id)
        {
            // Get product from database

            // Add product to cart cookie

            // Redirect back to previous page

            return View();
        }

        public IActionResult Summary()
        {
            // Display all products in shopping cart cookie

            return View();
        }
    }
}
