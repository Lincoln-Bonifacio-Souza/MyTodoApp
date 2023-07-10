#nullable disable

using System;
using System.ComponentModel.DataAnnotations;

namespace MyTodoApp.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
