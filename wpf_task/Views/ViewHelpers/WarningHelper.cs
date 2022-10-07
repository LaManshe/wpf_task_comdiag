using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace wpf_task.ViewHelpers
{
    public class WarningHelper
    {
        internal void Point(Control control)
        {
            control.BorderBrush = Brushes.Red;
        }
    }
}
