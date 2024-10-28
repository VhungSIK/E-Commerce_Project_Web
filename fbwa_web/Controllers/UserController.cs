using Microsoft.AspNetCore.Mvc;
using fbwa_web.Data;
using fbwa_web.Models;
using System.Linq;

namespace fbwa_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FBWAContext _context;

        public UserController(FBWAContext context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _context.Users.ToList();

                if (users == null || users.Count == 0)
                {
                    return NotFound("No users found.");
                }

                // Xử lý các giá trị null để tránh lỗi
                var sanitizedUsers = users.Select(user => new
                {
                    UserID = user.UserID,
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty,
                    Email = user.Email,
                    Phone = user.Phone ?? string.Empty,
                    Address = user.Address ?? string.Empty,
                    DateCreated = user.DateCreated != DateTime.MinValue ? user.DateCreated : DateTime.Now,
                    IsActive = user.IsActive,
                    Gender = user.Gender ?? string.Empty,
                    AvatarUrl = user.AvatarUrl ?? string.Empty
                }).ToList();

                return Ok(sanitizedUsers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            // Thêm vai trò mặc định là "user" cho người dùng mới
            var userRole = new UserRole
            {
                UserID = user.UserID,
                RoleID = _context.Roles.FirstOrDefault(r => r.RoleName == "user")?.RoleID ?? 0
            };

            _context.UserRoles.Add(userRole);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { id = user.UserID }, user);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (id != updatedUser.UserID)
            {
                return BadRequest();
            }

            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Username = updatedUser.Username;
            user.PasswordHash = updatedUser.PasswordHash;
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.Phone = updatedUser.Phone;
            user.Address = updatedUser.Address;
            user.IsActive = updatedUser.IsActive;
            user.Gender = updatedUser.Gender;
            user.AvatarUrl = updatedUser.AvatarUrl;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
