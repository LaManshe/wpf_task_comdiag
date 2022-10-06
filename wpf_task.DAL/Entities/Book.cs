using System.ComponentModel.DataAnnotations;
using wpf_task.DAL.Entities.Base;

namespace wpf_task.DAL.Entities
{
    public class Book : Entity
    {
        [Required]
        public string Title { get; set; }
        public string? ShortDescription { get; set; }
        public int? Year { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public virtual Author Author { get; set; }
    }
}
