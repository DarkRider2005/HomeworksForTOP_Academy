using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
    public class MainViewModel : INotifyPropertyChanged
    {
        private ViewModelWriteTextBox _viewModelWriteTextBox;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            _viewModelWriteTextBox = new ViewModelWriteTextBox();
        }

        #region Свойства для TextBox, который выполняет функцию "Документа"
        public List<int> FontSizesDocument { get { return _viewModelWriteTextBox.FontSizes.ToList(); } }
        public string WriteTextDocument
        {
            get
            {
                return _viewModelWriteTextBox.WriteText;
            }
            set
            {
                _viewModelWriteTextBox.WriteText = value;
                OnPropertyChanged(nameof(WriteTextDocument));
            }
        }
        public int FontSizeDocument
        {
            get
            {
                return _viewModelWriteTextBox.FontSize;
            }
            set
            {
                _viewModelWriteTextBox.FontSize = value;
                OnPropertyChanged(nameof(FontSizeDocument));
            }
        }
        public double IndentLeftDocument
        {
            get { return _viewModelWriteTextBox.IndentLeft; }
            set
            {
                _viewModelWriteTextBox.IndentLeft = value;
                OnPropertyChanged(nameof(IndentLeftDocument));
            }
        }
        public double IndentRightDocument
        {
            get { return _viewModelWriteTextBox.IndentRight; }
            set
            {
                _viewModelWriteTextBox.IndentRight = value;
                OnPropertyChanged(nameof(IndentRightDocument));
            }
        }
        public double IndentUpDocument
        {
            get { return _viewModelWriteTextBox.IndentUp; }
            set
            {
                _viewModelWriteTextBox.IndentUp = value;
                OnPropertyChanged(nameof(IndentLeftDocument));
            }
        }
        public double IndentDownDocument
        {
            get { return _viewModelWriteTextBox.IndentDown; }
            set
            {
                _viewModelWriteTextBox.IndentDown = value;
                OnPropertyChanged(nameof(IndentDownDocument));
            }
        }
        public FontFamily FontFamilyDocument
        {
            get
            {
                return _viewModelWriteTextBox.FontFamily;
            }
            set
            {
                _viewModelWriteTextBox.FontFamily = value;
                OnPropertyChanged(nameof(FontFamilyDocument));
            }
        }
        public FontStyle FontStyleDocument
        {
            get => _viewModelWriteTextBox.FontStyle;
            set
            {
                _viewModelWriteTextBox.FontStyle = value;
                OnPropertyChanged(nameof(FontStyleDocument));
            }
        }
        public FontWeight FontWeightDocument
        {
            get => _viewModelWriteTextBox.FontWeight;
            set
            {
                _viewModelWriteTextBox.FontWeight = value;
                OnPropertyChanged(nameof(FontWeightDocument));
            }
        }
        public Thickness ThicknessDocument
        {
            get => _viewModelWriteTextBox.Thickness;
            set
            {
                _viewModelWriteTextBox.Thickness = value;
                OnPropertyChanged(nameof(ThicknessDocument));
            }
        }
        public Color FontColorDocument
        {
            get => _viewModelWriteTextBox.FontColor;
            set
            {
                _viewModelWriteTextBox.FontColor = value;
                OnPropertyChanged(nameof(FontColorDocument));
            }
        }
        public Color SelectionFontColorDocument
        {
            get => _viewModelWriteTextBox.SelectionFontColor;
            set
            {
                _viewModelWriteTextBox.SelectionFontColor = value;
                OnPropertyChanged(nameof(SelectionFontColorDocument));
            }
        }
        public List<Color> FontColors { get { return _viewModelWriteTextBox.FontColors; } }
        #endregion
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}