namespace fbwa_web.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
