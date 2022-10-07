using wpf_task.DAL.Entities.Base;

namespace wpf_task.DAL.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string? ShortDescription { get; set; }
        public int? Year { get; set; }
        public string ISBN { get; set; }
        public string Base64Image { get; set; }
        public virtual Author Author { get; set; }
        
    }
}
