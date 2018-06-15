using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Client.Common
{
    public class DialogService
    {
        public bool? ShowDialog(ViewModel viewModel)
        {
            return false;
            //CustomWindow window = new CustomWindow(viewModel)
            //{
            //    ShowInTaskbar = false
            //};

            //return window.ShowDialog();
        }
    }
}
