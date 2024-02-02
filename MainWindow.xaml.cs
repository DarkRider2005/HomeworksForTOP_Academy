using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPFProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;
        }

        private void SliderAlfa_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _mainViewModel.CurrentAlfa = (byte)e.NewValue;
        }

        private void SliderRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _mainViewModel.CurrentRed = (byte)e.NewValue;
        }

        private void SliderGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _mainViewModel.CurrentGreen = (byte)e.NewValue;
        }

        private void SliderBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _mainViewModel.CurrentBlue = (byte)e.NewValue;
        }
        private void CheckedAlfaBox(object sender, RoutedEventArgs e)
        {
            AlfaSlider.IsEnabled = true;
            _mainViewModel.CurrentAlfa = (byte)AlfaSlider.Value;
        }
        private void UncheckedAlfaBox(object sender, RoutedEventArgs e)
        {
            AlfaSlider.IsEnabled = false;
            _mainViewModel.CurrentAlfa = 0;
        }

        private void CheckedRedBox(object sender, RoutedEventArgs e)
        {
            RedSlider.IsEnabled = true;
            _mainViewModel.CurrentRed = (byte)RedSlider.Value;
        }
        private void UncheckedRedBox(object sender, RoutedEventArgs e)
        {
            RedSlider.IsEnabled = false;
            _mainViewModel.CurrentRed = 0;
        }

        private void CheckedGreenBox(object sender, RoutedEventArgs e)
        {
            GreenSlider.IsEnabled = true;
            _mainViewModel.CurrentGreen = (byte)GreenSlider.Value;
        }
        private void UnCheckedGreenBox(object sender, RoutedEventArgs e)
        {
            GreenSlider.IsEnabled= false;
            _mainViewModel.CurrentGreen= 0;
        }

        private void CheckedBlueBox(object sender, RoutedEventArgs e)
        {
            BlueSlider.IsEnabled = true;
            _mainViewModel.CurrentBlue = (byte)BlueSlider.Value;
        }
        private void UnCheckedBlueBox(object sender, RoutedEventArgs e)
        {
            BlueSlider.IsEnabled = false;
            _mainViewModel.CurrentBlue = 0;
        }
    }
}