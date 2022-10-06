using Microsoft.EntityFrameworkCore;
using wpf_task.DAL.Data;
using wpf_task.DAL.Entities;

namespace wpf_task.DAL
{
    class BookRepository : Repository<Book>
    {
        public override IQueryable<Book> Items => base.Items.Include(item => item.Author);
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context) : base(context) { }
    }
}
