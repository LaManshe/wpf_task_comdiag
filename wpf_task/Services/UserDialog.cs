using MathCore.WPF.Services;
using System;
using System.Collections.Generic;
using System.IO;
using wpf_task.DAL.Entities;
using wpf_task.Services.Interfaces;
using wpf_task.ViewModels;
using wpf_task.Views;

namespace wpf_task.Services
{
    internal class UserDialog : IUserDialog
    {
        public bool Add(Book book, List<Author> authors)
        {
            var book_editor_model = new BookAddViewModel(book, authors);

            var book_editor_window = new BookAddWindow
            {
                DataContext = book_editor_model
            };

            if (book_editor_window.ShowDialog() != true) return false;

            book.Title = book_editor_model.Title;
            book.ShortDescription = book_editor_model.ShortDescription;
            book.ISBN = book_editor_model.ISBN;
            book.Year = book_editor_model.Year;
            book.Author = book_editor_model.Author;


            return true;
        }
        public bool AddAuthor(Author author)
        {
            var author_editor_model = new AuthorAddViewModel(author);

            var author_editor_window = new AuthorAddWindow
            {
                DataContext = author_editor_model
            };

            if (author_editor_window.ShowDialog() != true) return false;

            author.Name = author_editor_model.Name;
            author.Surname = author_editor_model.Surname;
            author.Patronymic = author_editor_model.Patronymic;


            return true;
        }
        public void Error(string Text, string Title = "Вопрос...")
        {
            throw new NotImplementedException();
        }

        public string? GetText(string Caption, string Title = "Введите текст", string? Default = "")
        {
            throw new NotImplementedException();
        }

        public void Information(string Text, string Title = "Вопрос...")
        {
            throw new NotImplementedException();
        }

        public bool OkCancelQuestion(string Text, string Title = "Вопрос...")
        {
            throw new NotImplementedException();
        }

        public FileInfo? OpenFile(string Title, string Filter = "Все файлы (*.*)|*.*", string? DefaultFilePath = null)
        {
            throw new NotImplementedException();
        }

        public IProgressInfo Progress(string Title, string Status, string? Information = null)
        {
            throw new NotImplementedException();
        }

        public FileInfo? SaveFile(string Title, string Filter = "Все файлы (*.*)|*.*", string? DefaultFilePath = null)
        {
            throw new NotImplementedException();
        }

        public void Warning(string Text, string Title = "Вопрос...")
        {
            throw new NotImplementedException();
        }

        public bool YesNoQuestion(string Text, string Title = "Вопрос...")
        {
            throw new NotImplementedException();
        }
    }
}
