namespace fbwa_web.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public User User { get; set; }
    }
}
