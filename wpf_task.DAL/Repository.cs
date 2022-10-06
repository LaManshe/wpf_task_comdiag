using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using wpf_task.DAL.Data;
using wpf_task.DAL.Entities.Base;
using wpf_task.Interfaces;

namespace wpf_task.DAL
{
    internal class Repository<T> : IRepository<T> 
        where T : Entity, new()
    {
        private readonly DbSet<T> _Set;
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
            _Set = context.Set<T>();
        }

        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _context.Entry(item).State = EntityState.Added;
            _context.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            _context.Entry(item).State = EntityState.Added;
            await _context.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public virtual IQueryable<T> Items => _Set;

        public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);

        public Task<T> GetAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var item = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new T { Id = id };

            _context.Remove(item);

            _context.SaveChanges();
        }

        public Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _context.Entry(item).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public Task UpdateAsync(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
