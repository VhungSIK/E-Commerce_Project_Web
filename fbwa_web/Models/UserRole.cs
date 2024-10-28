using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fbwa_web.Models
{
    public class UserRole
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }

        [Key, Column(Order = 1)]
        public int RoleID { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
