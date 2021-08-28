using eCommerceProject.Data;
using eCommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceProject.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductContext _context;

        public ProductController(ProductContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Displays a view that lists a page of products
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(int? id)
        {
            int pageNum = id ?? 1;
            const int PageSize = 3;
            ViewData["CurrentPage"] = pageNum;

            int numProducts = await ProductDb.GetTotalProductsAsync(_context);

            int totalPages = (int)Math.Ceiling((double)numProducts / PageSize);

            ViewData["MaxPage"] = totalPages;

            // Get all products from database
            List<Product> products = await ProductDb.GetProductsAsync(_context, PageSize, pageNum);

            // Send list of products to view to be displayed
            return View(products);
        }

        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product p) 
        {
            if (ModelState.IsValid) 
            {
                await ProductDb.AddProductAsync(_context, p);

                TempData["Message"] = $"{p.Title} was added successfully";

                // redirect back to catalog page
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            // Get product with corresponding id
            Product p =
                await (from prod in _context.Products
                 where prod.ProductID == id
                 select prod).SingleAsync();

            // pass product to view
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(p).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                TempData["Message"] = "Product updated successfully";

                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Product p =
                await (from prod in _context.Products
                 where prod.ProductID == id
                 select prod).SingleAsync();

            return View(p);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Product p =
                await (from prod in _context.Products
                       where prod.ProductID == id
                       select prod).SingleAsync();

            _context.Entry(p).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            TempData["Message"] = $"{p.Title} was deleted";

            return RedirectToAction("Index");
        }
    }
}
