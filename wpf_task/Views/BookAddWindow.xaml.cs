using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpf_task.Views
{
    /// <summary>
    /// Логика взаимодействия для BookAddWindow.xaml
    /// </summary>
    public partial class BookAddWindow : Window
    {
        public BookAddWindow()
        {
            InitializeComponent();
        }

        private bool IsDigit(Key key) => key >= Key.D0 && key <= Key.D9 || key >= Key.NumPad0 && key <= Key.NumPad9;

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(!IsDigit(e.Key)) e.Handled = true;
        }
    }
}
