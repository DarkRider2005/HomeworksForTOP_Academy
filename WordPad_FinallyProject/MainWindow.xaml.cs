using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordPad_FinallyProject.ViewModel;
using Microsoft.VisualBasic;

namespace WordPad_FinallyProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;

        public MainWindow()
        {
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;
            InitializeComponent();
        }

        private void FontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainViewModel.FontFamilyDocument = new FontFamily(FontComboBox.SelectedItem.ToString());
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainViewModel.FontSizeDocument = _mainViewModel.FontSizesDocument[FontSizeComboBox.SelectedIndex];
        }

        private void FontColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainViewModel.FontColorDocument = _mainViewModel.FontColors[FontColorComboBox.SelectedIndex];
        }

        private void SelectionFontColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainViewModel.SelectionFontColorDocument = _mainViewModel.FontColors[SelectionFontColorComboBox.SelectedIndex];
        }

        private void ButtonIncreaseFontSizeForDocument(object sender, RoutedEventArgs e)
        {
            FontSizeComboBox.SelectedIndex++;
        }

        private void ButtonReduceFontSizeForDocument(object sender, RoutedEventArgs e)
        {
            if (FontSizeComboBox.SelectedIndex > 0)
                FontSizeComboBox.SelectedIndex--;
        }

        private int i = 0; //
        private void ButtonBoldTextForDocument(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            if (i == 0)
            {
                _mainViewModel.FontWeightDocument = FontWeights.Bold;
                i++;
            }
            else
            {
                _mainViewModel.FontWeightDocument = FontWeights.Normal;
                i = 0;
            }
        }
        private int j = 0;
        private void ButtonItalicTextForDocument(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            if (j == 0)
            {
                _mainViewModel.FontStyleDocument = FontStyles.Oblique;
                j++;
            }
            else
            {
                _mainViewModel.FontStyleDocument = FontStyles.Normal;
                j = 0;
            }
        }

        private void ButtonChangeIndentLeft(object sender, RoutedEventArgs e)
        {
            InputPaddingBox paddingBox = new InputPaddingBox("Введите значение отступа слева");
            paddingBox?.ShowDialog();
        }
    }
}