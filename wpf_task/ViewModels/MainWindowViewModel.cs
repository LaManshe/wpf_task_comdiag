using MathCore.Values;
using MathCore.WPF;
using MathCore.WPF.Commands;
using MathCore.WPF.Services;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using wpf_task.DAL.Entities;
using wpf_task.Interfaces;
using wpf_task.Services.Interfaces;

namespace wpf_task.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region ПРИВАТНЫЕ ПОЛЯ И СВОЙСТВА ДЛЯ КОНТЕКСТА ДАННЫХ
        private string _Title = "Каталог Книг";
        private ObservableCollection<Book> _Books;
        private Book? _SelectedBook;
        #endregion

        #region ПУБЛИЧНЫЕ ПОЛЯ И СВОЙСТВА ДЛЯ ОТОБРАЖЕНИЯ ДАННЫХ
        public string Title { get => _Title; set => Set(ref _Title, value); }
        
        public ObservableCollection<Book> Books 
        {
            get => _Books;
            set => Set(ref _Books, value);
        }
        
        public Book? SelectedBook { get => _SelectedBook; set => Set(ref _SelectedBook, value); }
        #endregion

        #region ПОЛУЧЕНИЕ СПИСКА КНИГ ПРИ ЗАГРУЗКЕ ПРИЛОЖЕНИЯ


        private ICommand _GetBooks;

        public ICommand GetBooks => _GetBooks
            ??= new LambdaCommand(OnGetBooksExecuted, CanGetBooksExecute);

        private bool CanGetBooksExecute() => true;

        private void OnGetBooksExecuted()
        {
            Books = new ObservableCollection<Book>();
            var books_query_all = _booksRepo.Items;
            foreach(var book in books_query_all)
            {
                Books.Add(book);
            }
            
        }
        #endregion

        #region ДОБАВЛЕНИЕ КНИГИ В БД
        private ICommand _AddNewBookCommand;

        public ICommand AddNewBookCommand => _AddNewBookCommand
            ??= new LambdaCommand(OnAddNewBookCommandExecuted, CanAddNewBookCommandExecute);

        private bool CanAddNewBookCommandExecute() => true;

        private void OnAddNewBookCommandExecuted()
        {
            var new_book = new Book();
            var allow_authors = _authorRepo.Items.ToList();

            if (!_userDialog.Add(ref new_book, allow_authors))
                return;

            FieldInfo[] fields = new_book.GetType().GetFields(BindingFlags.Public |
                                          BindingFlags.NonPublic |
                                          BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                var val = field.GetValue(new_book);
                if (val == String.Empty || val == null)
                {
                    MessageBox.Show("Нужно заполнить все поля");
                    return;
                }
            }

            _Books.Add(_booksRepo.Add(new_book));

            SelectedBook = new_book;
        }
        #endregion

        #region ИЗМЕНЕНИЯ КНИГИ В БД
        private ICommand _EditBookCommand;

        public ICommand EditBookCommand => _EditBookCommand
            ??= new LambdaCommand<Book>(OnEditBookCommandExecuted, CanEditBookCommandExecute);

        private bool CanEditBookCommandExecute(Book book) => book != null || SelectedBook != null;
        private void OnEditBookCommandExecuted(Book book)
        {
            var edit_book = book;
            var allow_authors = _authorRepo.Items.ToList();

            if (!_userDialog.Add(ref edit_book, allow_authors)) return;

            FieldInfo[] fields = edit_book.GetType().GetFields(BindingFlags.Public |
                                          BindingFlags.NonPublic |
                                          BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                var val = field.GetValue(edit_book);
                if (val == String.Empty || val == null)
                {
                    MessageBox.Show("Нельзя оставлять поля пустыми");
                    return;
                }
            }

            _booksRepo.Update(edit_book);

            SelectedBook = edit_book;

            OnGetBooksExecuted();
        }
        #endregion

        #region УДАЛЕНИЕ КНИГИ ИЗ БД
        private ICommand _RemoveBookCommand;

        public ICommand RemoveBookCommand => _RemoveBookCommand
            ??= new LambdaCommand<Book>(OnRemoveBookCommandExecuted, CanRemoveBookCommandExecute);

        private bool CanRemoveBookCommandExecute(Book book) => book != null || SelectedBook != null;

        private void OnRemoveBookCommandExecuted(Book book)
        {
            Book book_to_remove = book ?? SelectedBook;
            _booksRepo.Remove(book_to_remove.Id);

            Books.Remove(book_to_remove);
            if (ReferenceEquals(SelectedBook, book_to_remove))
                SelectedBook = null;
        }
        #endregion

        #region ДОБАВЛЕНИЕ АВТОРА В БД
        private ICommand _AddNewAuthorCommand;

        public ICommand AddNewAuthorCommand => _AddNewAuthorCommand
            ??= new LambdaCommand(OnAddNewAuthorCommandExecuted, CanAddNewAuthorCommandExecute);

        private bool CanAddNewAuthorCommandExecute() => true;

        private void OnAddNewAuthorCommandExecuted()
        {
            var new_author = new Author();

            if (!_userDialog.AddAuthor(new_author))
                return;

            FieldInfo[] fields = new_author.GetType().GetFields(BindingFlags.Public |
                                          BindingFlags.NonPublic |
                                          BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                var val = field.GetValue(new_author);
                if (val == String.Empty || val == null)
                {
                    MessageBox.Show("Нужно заполнить все поля");
                    return;
                }
            }

            _authorRepo.Add(new_author);
        }
        #endregion

        #region КОНСТРУКТОР
        #region ПРИВАТНЫЕ ПОЛЯ ДЛЯ ВНЕДЕРЕННЫХ ЗАВИСИМОСТЕЙ
        private readonly IRepository<Book> _booksRepo;
        private readonly IRepository<Author> _authorRepo;
        private readonly IUserDialog _userDialog;
        #endregion
        public MainWindowViewModel(IRepository<Book> booksRepo, IRepository<Author> authorRepo, IUserDialog userDialog)
        {
            _booksRepo = booksRepo;
            _authorRepo = authorRepo;
            _userDialog = userDialog;

            OnGetBooksExecuted();
        }
        #endregion
    }
}
