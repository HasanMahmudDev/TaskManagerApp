using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Application.ViewModels;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _service;
        private readonly IWebHostEnvironment _env;

        public TaskController(ITaskService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        // GET: Task/Index
        public async Task<IActionResult> Index()
        {
            var tasks = await _service.GetAllAsync();
            return View(tasks);
        }

        // GET: Task/Create
        public IActionResult Create()
        {
            ViewBag.Priorities = Enum.GetValues(typeof(TaskPriority));
            return View();
        }

        // GET: Task/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null) return NotFound();

            var vm = new TaskEntryViewModel
            {
                Title = task.Title,
                Description = task.Description,
                AssignedTo = task.AssignedTo,
                CompanyName = task.CompanyName,
                Module = task.Module,
                RequirementType = task.RequirementType,
                Tag = task.Tag,
                IsPreviousWork = task.IsPreviousWork,
                CreateDate = task.CreateDate,
                EstdTime = task.EstdTime,
                Priority = task.Priority
            };

            return View(vm);
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskEntryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Title = model.Title;
            existing.Description = model.Description;
            existing.AssignedTo = model.AssignedTo;
            existing.CompanyName = model.CompanyName;
            existing.Module = model.Module;
            existing.RequirementType = model.RequirementType;
            existing.Tag = model.Tag;
            existing.IsPreviousWork = model.IsPreviousWork;
            existing.CreateDate = model.CreateDate;
            existing.EstdTime = model.EstdTime;
            existing.Priority = model.Priority;

            await _service.UpdateAsync(existing);
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null) return NotFound();
            return View(task);
        }


        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskEntryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string filePath = null;
            if (model.Upload != null)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Upload.FileName);
                filePath = Path.Combine("uploads", fileName);

                var fullPath = Path.Combine(_env.WebRootPath, filePath);
                using var fileStream = new FileStream(fullPath, FileMode.Create);
                await model.Upload.CopyToAsync(fileStream);
            }

            var task = new TaskItem
            {
                Title = model.Title,
                Description = model.Description,
                AssignedTo = model.AssignedTo,
                CompanyName = model.CompanyName,
                Module = model.Module,
                RequirementType = model.RequirementType,
                Tag = model.Tag,
                IsPreviousWork = model.IsPreviousWork,
                CreateDate = model.CreateDate,
                EstdTime = model.EstdTime,
                Priority = model.Priority,
                Status = Domain.Enums.TaskStatus.Pending,
                FilePath = filePath
            };

            await _service.CreateAsync(task);
            return RedirectToAction(nameof(Index));
        }
    }
}
