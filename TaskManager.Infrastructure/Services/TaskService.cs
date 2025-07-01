using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Common.Interfaces;
using TaskManager.Application.Services;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<TaskItem> _repository;

        public TaskService(IRepository<TaskItem> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync() => await _repository.GetAllAsync();
        public async Task<TaskItem?> GetTaskByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task CreateTaskAsync(TaskItem task) => await _repository.AddAsync(task);
        public async Task UpdateTaskAsync(TaskItem task) => await _repository.UpdateAsync(task);
        public async Task DeleteTaskAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task != null)
                await _repository.DeleteAsync(task);
        }
    }
}
