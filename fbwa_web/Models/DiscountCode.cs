namespace fbwa_web.Models
{
    public class DiscountCode
    {
        public int DiscountCodeID { get; set; }
        public string Code { get; set; } = string.Empty;
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxUses { get; set; }
        public int TimesUsed { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}
