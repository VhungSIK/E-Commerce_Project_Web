using System.Collections.Generic;

namespace fbwa_web.Models
{
    public class CategoryProductViewModel
    {
        public Category ParentCategory { get; set; } = new Category(); // Khởi tạo mặc định để tránh lỗi null
        public List<SubCategoryProductViewModel> SubCategories { get; set; } = new List<SubCategoryProductViewModel>(); // Khởi tạo mặc định
    }

    public class SubCategoryProductViewModel
    {
        public Category SubCategory { get; set; } = new Category(); // Khởi tạo mặc định
        public List<Product> Products { get; set; } = new List<Product>(); // Khởi tạo mặc định
    }
}
