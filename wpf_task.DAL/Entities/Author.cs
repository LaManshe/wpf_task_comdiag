using wpf_task.DAL.Entities.Base;

namespace wpf_task.DAL.Entities
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}