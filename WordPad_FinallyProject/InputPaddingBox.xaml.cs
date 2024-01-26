using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordPad_FinallyProject.ViewModel;

namespace WordPad_FinallyProject
{
    /// <summary>
    /// Interaction logic for InputPaddingBox.xaml
    /// </summary>
    public partial class InputPaddingBox : Window
    {
        private ViewModelInputBox _inputViewModel;
        public InputPaddingBox(string title)
        {
            _inputViewModel = new ViewModelInputBox(title);
            DataContext = _inputViewModel;
            InitializeComponent();
        }
    }
}
