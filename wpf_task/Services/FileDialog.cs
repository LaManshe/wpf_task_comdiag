using MathCore.WPF.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpf_task.Services
{
    internal class FileDialog : IUserDialogBase
    {
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
            var fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter = Filter;
            fileDialog.Title = Title;

            var result = fileDialog.GetFileInfo();

            return result;
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
