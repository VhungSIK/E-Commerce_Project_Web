﻿namespace fbwa_web.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string SKU { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
