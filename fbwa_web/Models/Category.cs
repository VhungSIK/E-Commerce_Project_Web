namespace fbwa_web.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int? ParentCategoryID { get; set; }

        public Category? ParentCategory { get; set; } // Nullable để tránh lỗi khi không có danh mục cha
        public ICollection<Category> SubCategories { get; set; } = new List<Category>(); // Khởi tạo mặc định
        public ICollection<Product> Products { get; set; } = new List<Product>(); // Khởi tạo mặc định để tránh lỗi null
    }
}
