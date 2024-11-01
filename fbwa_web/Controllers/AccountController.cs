using Microsoft.AspNetCore.Mvc;
using fbwa_web.Models;
using fbwa_web.Data;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace fbwa_web.Controllers
{
    public class AccountController : Controller
    {
        private readonly FBWAContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountController(FBWAContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        // Rehash Passwords - This is a temporary action
        // Please remove this after executing it in a development environment
        public IActionResult RehashPasswords()
        {
            var users = _context.Users.ToList();
            foreach (var user in users)
            {
                // Kiểm tra nếu PasswordHash không phải là chuỗi Base64 hợp lệ của ASP.NET Identity
                // Hoặc bạn có thể sử dụng điều kiện khác nếu biết định dạng chính xác
                if (!user.PasswordHash.StartsWith("$2b$") && !user.PasswordHash.StartsWith("$argon2$"))
                {
                    // Đặt lại mật khẩu cho người dùng với một mật khẩu mặc định (nên là mật khẩu an toàn)
                    string newPassword = "defaultPassword123";  // Mật khẩu tạm thời, bạn có thể thay đổi thành bất kỳ mật khẩu nào

                    // Mã hóa lại mật khẩu bằng PasswordHasher
                    user.PasswordHash = _passwordHasher.HashPassword(user, newPassword);
                    _context.SaveChanges();
                }
            }
            return Content("Rehashed all passwords to be compatible with ASP.NET Identity.");
        }

        // Register - Get
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Register - Post
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại");
                    return View(model);
                }

                var user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    PasswordHash = _passwordHasher.HashPassword(new User(), model.Password),
                    IsActive = true,
                    DateCreated = DateTime.Now
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                var defaultRole = _context.Roles.FirstOrDefault(r => r.RoleName == "user");
                if (defaultRole != null)
                {
                    var userRole = new UserRole
                    {
                        UserID = user.UserID,
                        RoleID = defaultRole.RoleID
                    };
                    _context.UserRoles.Add(userRole);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // Login - Get
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login - Post
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.Email == model.Email);
                if (user != null)
                {
                    var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
                    if (passwordVerificationResult == PasswordVerificationResult.Success)
                    {
                        var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserID == user.UserID);
                        if (userRole != null)
                        {
                            var role = _context.Roles.FirstOrDefault(r => r.RoleID == userRole.RoleID);
                            if (role != null && role.RoleName == "admin")
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Mật khẩu không chính xác");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email không tồn tại");
                }
            }
            return View(model);
        }
    }
}
