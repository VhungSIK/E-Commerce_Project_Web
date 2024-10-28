namespace fbwa_web.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int? ParentCategoryID { get; set; }

        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }
    }
}
