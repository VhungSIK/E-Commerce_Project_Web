namespace fbwa_web.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int UserID { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
