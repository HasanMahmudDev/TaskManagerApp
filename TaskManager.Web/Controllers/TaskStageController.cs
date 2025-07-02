using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Persistence.Context;

namespace TaskManager.Web.Controllers
{
    public class TaskStageController : Controller
    {
        private readonly AppDbContext _context;

        public TaskStageController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskStages.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskStage taskStage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskStage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskStage);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var stage = await _context.TaskStages.FindAsync(id);
            if (stage == null) return NotFound();
            return View(stage);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskStage taskStage)
        {
            if (ModelState.IsValid)
            {
                _context.Update(taskStage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskStage);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var stage = await _context.TaskStages.FindAsync(id);
            return View(stage);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stage = await _context.TaskStages.FindAsync(id);
            _context.TaskStages.Remove(stage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}
