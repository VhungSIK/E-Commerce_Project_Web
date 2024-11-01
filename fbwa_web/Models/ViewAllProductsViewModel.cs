using System.Collections.Generic;

namespace fbwa_web.Models
{
    public class ViewAllProductsViewModel
    {
        public Category Category { get; set; } = new Category(); // Khởi tạo mặc định
        public List<Product> Products { get; set; } = new List<Product>(); // Khởi tạo mặc định
    }
}
