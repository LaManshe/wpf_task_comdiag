using MathCore.WPF.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_task.DAL.Entities;
using wpf_task.Interfaces;

namespace wpf_task.Data
{
    public class DbInit
    {
        private readonly IRepository<Book> _booksRepo;
        private readonly IRepository<Author> _authorRepo;
        public DbInit(IRepository<Book> booksRepo, IRepository<Author> authorRepo)
        {
            _booksRepo = booksRepo;
            _authorRepo = authorRepo;
        }

        public async Task InitializeAsync()
        {
            var books = _booksRepo.Items.ToArray();
            if (books.Count() < 1)
            {
                Random rnd = new Random();

                List<Author> authorList = new List<Author>();
                for(int i = 0; i < 10; i++)
                {
                    authorList.Add(new Author() { Name = $"Имя {i}", Surname = $"Фамилия {i}", Patronymic = $"Отчество {i}" });
                }

                List<Book> initBooks = new List<Book>();
                for(int i = 0; i < 50; i++)
                {
                    int rndIndexAuthor = rnd.Next(0, authorList.Count - 1);
                    initBooks.Add(new Book()
                    {
                        Title = $"Книга {i}",
                        ShortDescription = $"ОООООООООчень короткое описание книги {i}",
                        ISBN = $"",
                        Year = 2022,
                        Author = authorList[rndIndexAuthor]
                    });
                }

                foreach (var author in authorList)
                {
                    _authorRepo.Add(author);
                }
                foreach (var book in initBooks)
                {
                    _booksRepo.Add(book);
                }
            }
        }
    }
}
