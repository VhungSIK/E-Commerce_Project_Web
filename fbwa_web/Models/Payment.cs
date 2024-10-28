namespace fbwa_web.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string TransactionID { get; set; } = string.Empty;
        public int PaymentStatusID { get; set; }

        public Order Order { get; set; }
    }
}
