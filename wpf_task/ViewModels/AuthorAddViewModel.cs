using MathCore.Values;
using MathCore.WPF.ViewModels;
using wpf_task.DAL.Entities;

namespace wpf_task.ViewModels
{
    internal class AuthorAddViewModel : ViewModel
    {
        private string _Name;
        private string _Surname;
        private string _Patronymic;

        public string Name { get => _Name; set => Set(ref _Name, value); }
        public string Surname { get => _Surname; set => Set(ref _Surname, value); }
        public string Patronymic { get => _Patronymic; set => Set(ref _Patronymic, value); }

        public AuthorAddViewModel(Author author)
        {
            Name = author.Name;
            Surname = author.Surname;
            Patronymic = author.Patronymic;
        }
    }
}
