using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Web.Controllers
{
    public class UserController : Controller
    {
        // Simulated in-memory user list for demonstration
        private static List<User> _users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    Username = "hasan",
                    Email = "hasan@example.com",
                    PasswordHash = "",
                    Role = UserRole.User,
                    IsActive = true,
                    EmployeeProfile = null,
                    Comments = new List<Comment>(),
                    CreatedTasks = new List<TaskItem>()
                },
                new User
                {
                    UserId = 2,
                    Username = "mahmud",
                    Email = "mahmud@example.com",
                    PasswordHash = "",
                    Role = UserRole.User,
                    IsActive = true,
                    EmployeeProfile = null,
                    Comments = new List<Comment>(),
                    CreatedTasks = new List<TaskItem>()
                }
            };

        // GET: /User
        public IActionResult Index()
        {
            return View(_users);
        }

        // GET: /User/Details/5
        public IActionResult Details(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
                return NotFound();
            return View(user);
        }

        // GET: /User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserId = _users.Any() ? _users.Max(u => u.UserId) + 1 : 1;
                user.Comments = new List<Comment>();
                user.CreatedTasks = new List<TaskItem>();
                _users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: /User/Edit/5
        public IActionResult Edit(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
                return NotFound();
            return View(user);
        }

        // POST: /User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {
            if (id != user.UserId)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var existing = _users.FirstOrDefault(u => u.UserId == id);
                if (existing == null)
                    return NotFound();

                existing.Username = user.Username;
                existing.Email = user.Email;
                existing.PasswordHash = user.PasswordHash;
                existing.Role = user.Role;
                existing.IsActive = user.IsActive;
                existing.EmployeeProfile = user.EmployeeProfile;
                // Comments and CreatedTasks are not updated here for simplicity
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: /User/Delete/5
        public IActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
                return NotFound();
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
                _users.Remove(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
