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
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _repository;

        public ProjectService(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Project>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Project?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task CreateAsync(Project project) => await _repository.AddAsync(project);

        public async Task UpdateAsync(Project project) => await _repository.UpdateAsync(project);

        public async Task DeleteAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item != null)
                await _repository.DeleteAsync(item);
        }
    }
}
