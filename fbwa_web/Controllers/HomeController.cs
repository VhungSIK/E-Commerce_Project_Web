using Microsoft.AspNetCore.Mvc;
using fbwa_web.Data;
using fbwa_web.Models;
using System.Linq;
using System.Collections.Generic;

namespace fbwa_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly FBWAContext _context;

        public HomeController(FBWAContext context)
        {
            _context = context;
        }

        // Trang chủ hiển thị các danh mục và sản phẩm
        public IActionResult Index()
        {
            // Lấy tất cả các danh mục cha
            var parentCategories = _context.Categories
                .Where(c => c.ParentCategoryID == null)
                .ToList();

            var categoryProductData = new List<CategoryProductViewModel>();

            foreach (var parentCategory in parentCategories)
            {
                var subCategories = _context.Categories
                    .Where(c => c.ParentCategoryID == parentCategory.CategoryID)
                    .ToList();

                var subCategoryData = new List<SubCategoryProductViewModel>();

                foreach (var subCategory in subCategories)
                {
                    // Lấy tối đa 5 sản phẩm cho mỗi danh mục con
                    var products = _context.Products
                        .Where(p => p.CategoryID == subCategory.CategoryID && p.IsActive)
                        .Take(5)
                        .ToList();

                    subCategoryData.Add(new SubCategoryProductViewModel
                    {
                        SubCategory = subCategory,
                        Products = products
                    });
                }

                categoryProductData.Add(new CategoryProductViewModel
                {
                    ParentCategory = parentCategory,
                    SubCategories = subCategoryData
                });
            }

            return View(categoryProductData);
        }

        // Trang hiển thị tất cả sản phẩm của một danh mục con
        public IActionResult ViewAllProducts(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            var products = _context.Products
                .Where(p => p.CategoryID == categoryId && p.IsActive)
                .ToList();

            var model = new ViewAllProductsViewModel
            {
                Category = category,
                Products = products
            };

            return View(model);
        }
    }
}
