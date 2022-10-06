using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using wpf_task.Interfaces;

namespace wpf_task.DAL.Entities.Base
{
    public abstract class Entity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
