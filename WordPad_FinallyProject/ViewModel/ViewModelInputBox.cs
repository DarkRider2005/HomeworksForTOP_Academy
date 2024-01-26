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
using WordPad_FinallyProject.Model;

namespace WordPad_FinallyProject.ViewModel
{
    public class ViewModelInputBox : INotifyPropertyChanged
    {
        private ModelInputBox _inputBox;
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelInputBox(string title)
        {
            _inputBox = new ModelInputBox();
            TitleActionText = title;
        }

        public string TitleActionText
        {
            get { return _inputBox.TitleAction; }
            set
            {
                _inputBox.TitleAction = value;
                Debug.WriteLine("Зашел из ViewModel");
                OnPropertyChanged(nameof(TitleActionText));
            }
        }

        public string ValueText
        {
            get => _inputBox.Value;
            set
            {
                _inputBox.Value = value;
                OnPropertyChanged(nameof(ValueText));
            }
        }

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
