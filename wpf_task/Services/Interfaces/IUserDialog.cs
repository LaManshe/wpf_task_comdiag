using MathCore.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_task.DAL.Entities;

namespace wpf_task.Services.Interfaces
{
    public interface IUserDialog : IUserDialogBase
    {
        bool Add(ref Book book, List<Author> authors);

        bool AddAuthor(Author author);
    }
}
