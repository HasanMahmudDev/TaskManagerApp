using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.ViewModels
{
    public class TaskEntryViewModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string CompanyName { get; set; }

        public string Module { get; set; }

        public string RequirementType { get; set; }

        public string AssignedTo { get; set; }

        public string Tag { get; set; }

        public bool IsPreviousWork { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public TimeSpan EstdTime { get; set; }

        public TaskPriority Priority { get; set; }

        public IFormFile Upload { get; set; }
    }
}
