using MathCore.CSV;
using MathCore.WPF.Commands;
using MathCore.WPF.Services;
using MathCore.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Input;
using wpf_task.DAL.Entities;
using wpf_task.Services;
using wpf_task.Services.Interfaces;

namespace wpf_task.ViewModels
{
    internal class BookAddViewModel : ViewModel
    {
        private string _Title;
        private string _ShortDescription;
        private string _ISBN;
        private int? _Year;
        private string _Base64Image;
        private Author _Author;
        private List<Author> _Authors;
        public string Title { get => _Title; set => Set(ref _Title, value); }
        public string ShortDescription { get => _ShortDescription; set => Set(ref _ShortDescription, value); }
        public string ISBN { get => _ISBN; set => Set(ref _ISBN, value); }
        public int? Year { get => _Year; set => Set(ref _Year, value); }
        public string Base64Image { get => _Base64Image; set => Set(ref _Base64Image, value); }
        public Author Author { get => _Author; set => Set(ref _Author, value); }
        public List<Author> Authors { get => _Authors; set => Set(ref _Authors, value); }


        private ICommand _BrowseImageCommand;
        public ICommand BrowseImageCommand => _BrowseImageCommand
            ??= new LambdaCommand(OnBrowseImageCommandExecuted, CanBrowseImageCommandExecute);

        private bool CanBrowseImageCommandExecute() => true;
        private void OnBrowseImageCommandExecuted()
        {
            var fileInfo = _fileDialog.OpenFile("Загрузить изображение", "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg");

            if (fileInfo == null) return;

            Base64Image = _base64Converter.ConvertImageToBase64(fileInfo.FullName);
        }

        private readonly IUserDialogBase _fileDialog;
        private readonly IFileConverter _base64Converter;
        public BookAddViewModel(Book book, List<Author> authors)
        {
            Title = book.Title;
            ShortDescription = book.ShortDescription;
            ISBN = book.ISBN;
            Year = book.Year;
            Author = book.Author;

            Authors = authors;

            _fileDialog = App.Host.Services.GetService<IUserDialogBase>();
            _base64Converter = App.Host.Services.GetService<IFileConverter>();
        }
    }
}
