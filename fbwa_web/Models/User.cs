namespace fbwa_web.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public string? Gender { get; set; }
        public string? AvatarUrl { get; set; }
    }

}
