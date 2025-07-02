using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Services;
using TaskManager.Domain.Entities;

namespace TaskManager.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _service;
        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        public async Task<IActionResult> ProjectIndex() => View(await _service.GetAllAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(project);
                return RedirectToAction(nameof(ProjectIndex));
            }
            return View(project);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var project = await _service.GetByIdAsync(id);
            return project == null ? NotFound() : View(project);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(project);
                return RedirectToAction(nameof(ProjectIndex));
            }
            return View(project);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var project = await _service.GetByIdAsync(id);
            return project == null ? NotFound() : View(project);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(ProjectIndex));
        }
    }
}
