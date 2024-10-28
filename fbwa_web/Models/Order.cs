namespace fbwa_web.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public int? DiscountCodeID { get; set; }
        public int OrderStatusID { get; set; }
        public int PaymentMethodID { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string? BillingAddress { get; set; }
        public int ShippingMethodID { get; set; }
        public int? AssignedToEmployeeID { get; set; }
        public string Notes { get; set; } = string.Empty;

        public User User { get; set; }
        public DiscountCode DiscountCode { get; set; }
        public Employee AssignedEmployee { get; set; }
    }
}
