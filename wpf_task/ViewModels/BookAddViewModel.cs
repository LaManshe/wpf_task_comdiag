using MathCore.CSV;
using MathCore.WPF.ViewModels;
using System.Collections.Generic;
using System.Linq;
using wpf_task.DAL.Entities;

namespace wpf_task.ViewModels
{
    internal class BookAddViewModel : ViewModel
    {
        private string _Title;
        private string _ShortDescription;
        private string _ISBN;
        private int? _Year;
        private Author _Author;
        private List<Author> _Authors;
        public string Title { get => _Title; set => Set(ref _Title, value); }
        public string ShortDescription { get => _ShortDescription; set => Set(ref _ShortDescription, value); }
        public string ISBN { get => _ISBN; set => Set(ref _ISBN, value); }
        public int? Year { get => _Year; set => Set(ref _Year, value); }
        public Author Author { get => _Author; set => Set(ref _Author, value); }

        public List<Author> Authors { get => _Authors; set => Set(ref _Authors, value); }

        public BookAddViewModel(Book book, List<Author> authors)
        {
            Title = book.Title;
            ShortDescription = book.ShortDescription;
            ISBN = book.ISBN;
            Year = book.Year;
            Author = book.Author;

            Authors = authors;
        }
    }
}
