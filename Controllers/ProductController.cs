using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Telefon", Price = 9999, Description = "iPhone" },
            new Product { Id = 2, Name = "Laptop", Price = 19999, Description = "Mac" }
        };

        public IActionResult Index() => View(products);

        public IActionResult Details(int id) => View(products.FirstOrDefault(p => p.Id == id));

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) => View(products.FirstOrDefault(p => p.Id == id));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var existing = products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Description = product.Description;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) => View(products.FirstOrDefault(p => p.Id == id));

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                products.Remove(product);
            return RedirectToAction("Index");
        }
    }
}